const routes = [
  {
    path: "/",
    name: "anonymous",
    redirect: "films",
    component: () => import("layouts/AnonymousLayout.vue"),
    children: [
      {
        path: "films/",
        name: "films",
        component: () => import("pages/FilmsPage.vue"),
      },
      {
        path: "filmstudios/",
        name: "filmstudios",
        component: () => import("pages/FilmStudiosPage.vue"),
      },
    ],
  },

  {
    path: "/auth",
    name: "auth",
    component: () => import("layouts/AuthLayout.vue"),
    children: [
      {
        path: "signin",
        name: "signin",
        component: () => import("pages/SignInPage.vue"),
      },
      {
        path: "signup",
        name: "signup",
        component: () => import("pages/SignUpPage.vue"),
      },
    ],
  },

  {
    path: "/admin",
    name: "admin",
    component: () => import("layouts/AdminLayout.vue"),
    children: [
      //{ path: "", component: () => import("pages/.vue") },
    ],
  },

  {
    path: "/filmstudio",
    name: "filmstudio",
    component: () => import("layouts/FilmStudioLayout.vue"),
    children: [
      {
        path: "",
        name: "rentals",
        component: () => import("pages/BorrowedMoviesPage.vue"),
      },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
