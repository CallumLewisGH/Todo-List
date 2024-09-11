import { createRouter, createWebHistory } from 'vue-router';
import todoList from '../pages/todo.vue';
import login from '../pages/login.vue';
import signin from '@/pages/signin.vue';
import home from '@/pages/home.vue';
import defaultLayout from '../layouts/defaultLayout.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [

        { path: '/', name: 'home', component: home, meta: { layout: defaultLayout }  },
        { path: '/todo', name: 'todo-list', component: todoList, meta: { layout: defaultLayout }  },
        { path: '/login', name: 'login', component: login, meta: { layout: defaultLayout }  },
        { path: '/signin', name: 'signin', component: signin, meta: { layout: defaultLayout }  }

    ],
});

export default router;