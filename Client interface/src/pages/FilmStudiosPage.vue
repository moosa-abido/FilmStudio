<template>
  <q-page class="q-ma-xl">
    <q-table title="Film studios" :rows="rows" :columns="columns" row-key="name" />
  </q-page>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { ref } from 'vue';

const columns = [
  {
    name: 'filmStudioId',
    required: true,
    label: 'ID',
    align: 'left',
    field: "filmStudioId",
    format: val => `${val}`,
    sortable: true
  },
  { name: 'Name', align: 'center', label: 'Name', field: 'name', sortable: true },
]

const rows = ref([])

function getFilmsStudios() {
  api.get("/filmstudios"
  ).then(res => {
    rows.value = res.data;
    console.log(rows.value);
  }
  ).catch(error =>
    alert("Could not get film studios list")
  );
}

getFilmsStudios()

</script>
