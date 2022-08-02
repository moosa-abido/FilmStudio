<template>
  <q-page class="flex flex-center">
    <q-card>
      <q-card-section>
        <div class="text-h3">Login</div>
      </q-card-section>
      <q-card-section class="q-gutter-md" style="min-width: 350px;">
        <q-input outlined v-model="username" label="Username" @click="unauthorized = false" />
        <q-input v-model="password" outlined label="Password" :type="isPwd ? 'password' : 'text'"
          @click="unauthorized = false">
          <template v-slot:append>
            <q-icon :name="isPwd ? 'visibility_off' : 'visibility'" class="cursor-pointer" @click="isPwd = !isPwd" />
          </template>
        </q-input>
      </q-card-section>

      <q-card-actions class="flex flex-center">
        <q-btn outline @click="signIn">Sign in</q-btn>
      </q-card-actions>

      <q-banner class="text-white bg-red q-ma-md" v-if="unauthorized">
        Username or password incorrect! Please verify your crendentials
      </q-banner>

      <q-separator />

      <p class="flex flex-center q-mt-md q-mb-none">Or Sign up</p>
      <q-card-actions class="flex flex-center">
        <q-btn dense class="bg-primary text-white" :to="{ name: 'signup' }">Sign up</q-btn>
      </q-card-actions>

    </q-card>
  </q-page>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { useAuthStore } from 'src/stores/app-store';
import { ref } from 'vue';
import { useRouter, useRoute } from 'vue-router'
const isPwd = ref(true)
const username = ref("");
const password = ref("");

const authStore = useAuthStore();
const router = useRouter()

const unauthorized = ref(false)

function signIn() {
  api.post("/users/authenticate", {
    username: username.value,
    password: password.value
  }
  ).then(res => {
    authStore.setUser(res.data);

    let path = "admin";
    if (authStore.user.role == "film studio")
      path = "filmstudio";
    router.push({
      name: path
    });
  }
  ).catch(error =>
    unauthorized.value = true
  );
}
</script>
