import { defineStore } from "pinia";

export const useAuthStore = defineStore("auth", {
  state: () => ({
    user: null,
  }),
  getters: {
    loggedInUser() {
      if (this.user == null) {
        this.user = JSON.parse(localStorage.getItem("user"));
      }
      return this.user;
    },
  },
  actions: {
    setUser(user) {
      this.user = user;
      localStorage.setItem("user", JSON.stringify(user));
    },
    resetUser() {
      this.user = null;
      localStorage.removeItem("user");
    },
  },
});
