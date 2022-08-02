<template>
  <q-page class="q-ma-xl">
    <q-table title="Rentals" :rows="rows" :columns="columns" row-key="name">
      <template v-slot:top>
        <span class="text-h6">Rentals</span>
        <q-space />
        <q-btn color="primary" outline dense class="q-py-none" label="Borrow film" @click="borrowFilmDialog = true" />
      </template>
      <template v-slot:body-cell-action="props">
        <q-td :props="props">
          <div>
            <q-btn dense push class="q-py-none" color="info" @click="returnFilm(props.row)">Return</q-btn>
          </div>
          <div class="my-table-details">
            {{ props.row.details }}
          </div>
        </q-td>
      </template>
    </q-table>

    <q-dialog v-model="borrowFilmDialog" persistent>
      <q-card style="min-width: 350px">
        <q-card-section>
          <div class="text-h6">Borrow Film</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-select dense outlined v-model="rentedFilmId" :options="films" label="Films" option-value="filmId"
            option-label="name" />
        </q-card-section>

        <q-banner class="text-white bg-red q-ma-md" v-if="isRentError">
          {{ rentErrorMessage }}
        </q-banner>

        <q-card-actions align="right" class="text-primary">
          <q-btn flat label="Cancel" v-close-popup />
          <q-btn flat label="Borrow" @click="borrowFilm" />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </q-page>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { useAuthStore } from 'src/stores/app-store';
import { ref } from 'vue';
import { useQuasar } from 'quasar'

const columns = [
  {
    name: 'filmCopyId',
    required: true,
    label: 'ID',
    align: 'left',
    field: "filmId",
    format: val => `${val}`,
    sortable: true
  },
  { name: 'Film', align: 'center', label: 'Film Name', field: 'name', sortable: true },
  { name: 'ReleaseDate', align: 'center', label: 'Release Date', field: 'releaseDate', sortable: true },
  { name: 'Country', align: 'center', label: 'Country', field: 'country', sortable: true },
  { name: 'Director', align: 'center', label: 'Director', field: 'director', sortable: true },
  {
    name: 'action',
    label: 'Return',
    align: 'center',
    format: val => `${val}`,
    sortable: true
  },
]

const $q = useQuasar();
const rows = ref([])

const authStore = useAuthStore();

const filmStudioId = authStore.loggedInUser.filmStudio.filmStudioId;
const token = authStore.loggedInUser.token;

const config = {
  headers: { Authorization: `Bearer ${token}` }
};

// get film studio rentals
function getRentals() {
  api.get("/mystudio/rentals", config
  ).then(res => {
    res.data.forEach(row => {
      api.get(`/films/${row.filmId}`, config).then(filmResponse => {
        const film = filmResponse.data;
        delete film.filmCopies;
        film.filmCopyId = row.filmCopyId
        rows.value.push(film);
      })
    });
  }
  ).catch(error =>
    alert("Could not get rentals list")
  );
}

getRentals();

// get films logic
const films = ref([])

function getFilms() {
  api.get("/films"
  ).then(res => {
    films.value = res.data;
  }
  ).catch(error =>
    alert("Could not get films list")
  );
}

getFilms();

// borrow film logic
const isRentError = ref(false);
const rentErrorMessage = ref("");
const borrowFilmDialog = ref(false)

const rentedFilmId = ref(null)
function borrowFilm() {
  api.post(`/films/rent/?id=${rentedFilmId.value.filmId}&studioId=${filmStudioId}`, {}, config).then(response => {
    api.get(`/films/${rentedFilmId.value.filmId}`, config).then(filmResponse => {
      const film = filmResponse.data;
      delete film.filmCopies;
      film.filmCopyId = response.data.filmCopyId
      rows.value.push(film);
      borrowFilmDialog.value = false;
    })
  }).catch(error => {
    rentErrorMessage.value = error.response.data.message;
    isRentError.value = true;
    setTimeout(() => { borrowFilmDialog.value = false; isRentError.value = false }, 3000);
  })
}

// return film
function returnFilm(film) {
  api.post(`/films/return/?id=${film.filmId}&studioId=${filmStudioId}`, {}, config).then(response => {
    $q.dialog({
      title: 'Film Returned',
      message: `${film.name} film returned successfully!`
    });
    rows.value = rows.value.filter(filmCopy => filmCopy.filmCopyId != film.filmCopyId);
  })
}
</script>
