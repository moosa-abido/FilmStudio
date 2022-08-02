<template>
  <q-layout class="bg-grey-1">
    <q-header elevated class="text-white" style="background: #24292e" height-hint="61.59">
      <q-toolbar class="q-py-sm q-px-md">
        <q-icon name="img:logo.jpg" size="xl">
        </q-icon>

        <div class="GL__toolbar-link q-ml-xs q-gutter-md text-body2 text-weight-bold row items-center no-wrap">
          <q-btn outline :to="{ name: 'films' }" class="text-white"> Films </q-btn>
          <q-btn outline :to="{ name: 'filmstudios' }" class="text-white"> Film studios </q-btn>
        </div>

        <q-space />

        <div class="q-pl-sm q-gutter-sm row items-center no-wrap">
          <q-btn dense flat no-wrap :to="{ name: 'signin' }"> Sign in </q-btn>
        </div>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup>
</script>

<style lang="sass">
.GL
  &__select-GL__menu-link
    .default-type
      visibility: hidden

    &:hover
      background: #0366d6
      color: white
      .q-item__section--side
        color: white
      .default-type
        visibility: visible

  &__toolbar-link
    a
      color: white
      text-decoration: none
      &:hover
        opacity: 0.7

  &__menu-link:hover
    background: #0366d6
    color: white

  &__menu-link-signed-in,
  &__menu-link-status
    &:hover
      & > div
        background: white !important

  &__menu-link-status
    color: $blue-grey-6
    &:hover
      color: $light-blue-9

  &__toolbar-select.q-field--focused
    width: 450px !important
    .q-field__append
      display: none
</style>
