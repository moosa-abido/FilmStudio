<template>
  <q-page class="flex flex-center">
    <q-card>
      <q-card-section>
        <div class="text-h3">Sign up</div>
      </q-card-section>
      <q-tabs v-model="tab" dense class="text-grey" active-color="primary" indicator-color="primary" align="justify"
        narrow-indicator>
        <q-tab name="admin" label="Administrator" />
        <q-tab name="filmstudio" label="Film Studio" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated>
        <q-tab-panel name="admin" @click="signUpError = false">
          <q-card-section class="q-gutter-md" style="min-width: 400px;">
            <q-input dense outlined v-model="username" label="Username" />
            <q-input dense v-model="password" outlined label="Password" :type="isPwd ? 'password' : 'text'">
              <template v-slot:append>
                <q-icon :name="isPwd ? 'visibility_off' : 'visibility'" class="cursor-pointer"
                  @click="isPwd = !isPwd" />
              </template>
            </q-input>
          </q-card-section>
        </q-tab-panel>

        <q-tab-panel name="filmstudio" @click="signUpError = false">
          <q-card-section class="q-gutter-md" style="min-width: 400px;">
            <q-input dense outlined v-model="studioName" label="Studio Name" />
            <q-input dense outlined v-model="studioCity" label="Studio City" />

            <q-input dense outlined v-model="username" label="Username" />
            <q-input dense v-model="password" outlined label="Password" :type="isPwd ? 'password' : 'text'">
              <template v-slot:append>
                <q-icon :name="isPwd ? 'visibility_off' : 'visibility'" class="cursor-pointer"
                  @click="isPwd = !isPwd" />
              </template>
            </q-input>
          </q-card-section>


        </q-tab-panel>
      </q-tab-panels>

      <q-banner class="text-white bg-red q-ma-md" v-if="signUpError">
        {{ errorMsg }}
      </q-banner>

      <q-banner class="text-white bg-green q-ma-md" v-if="signUpSuccess">
        User signed up successfully!
      </q-banner>

      <q-card-actions class="flex flex-center">
        <q-btn outline @click="signUp">Sign up</q-btn>
      </q-card-actions>

      <q-separator />

      <p class="flex flex-center q-mt-md q-mb-none">Have an account?</p>
      <q-card-actions class="flex flex-center">
        <q-btn dense class="bg-primary text-white" :to="{ name: 'signin' }">Sign in</q-btn>
      </q-card-actions>
    </q-card>
  </q-page>
</template>

<script setup>
import { api } from 'src/boot/axios';
import { ref } from 'vue';

const tab = ref('admin')

const isPwd = ref(true)
const studioName = ref("");
const studioCity = ref("");
const username = ref("");
const password = ref("");

const errorMsg = ref("")
const signUpError = ref(false)
const signUpSuccess = ref(false)

function signUp() {
  const role = tab.value;
  let url = "/users/register"
  const user = {
    username: username.value,
    password: password.value
  }
  if (role == "filmstudio") {
    url = "/filmstudios/register"
    user.filmStudioCity = studioCity.value;
    user.filmStudioName = studioName.value;
  }

  api.post(url, user)
    .then(response => {
      signUpSuccess.value = true;
      setTimeout(() => {
        signUpSuccess.value = false;
      }, 5000);

    }).catch(error => {
      signUpError.value = true;
      errorMsg.value = error.response.data.message;
      setTimeout(() => signUpError.value = false, 10000);
    })
}
</script>
