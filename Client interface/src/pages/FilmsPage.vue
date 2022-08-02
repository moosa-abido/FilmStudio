<template>
  <q-page class="q-ma-xl">
    <q-table title="Films" :rows="rows" :columns="columns" row-key="name" />
  </q-page>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { ref } from 'vue';

const columns = [
  {
    name: 'filmId',
    required: true,
    label: 'ID',
    align: 'left',
    field: "filmId",
    format: val => `${val}`,
    sortable: true
  },
  { name: 'Name', align: 'center', label: 'Name', field: 'name', sortable: true },
  { name: 'ReleaseDate', align: 'center', label: 'Release Date', field: 'releaseDate', sortable: true },
  { name: 'Country', align: 'center', label: 'Country', field: 'country', sortable: true },
  { name: 'Director', align: 'center', label: 'Director', field: 'director', sortable: true },
]

const rows = ref([])

function getFilms() {
  api.get("/films"
  ).then(res => {
    rows.value = res.data;
  }
  ).catch(error =>
    alert("Could not get films list")
  );
}

getFilms()

</script>
