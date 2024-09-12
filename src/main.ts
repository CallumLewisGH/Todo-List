import { createApp } from 'vue';
import App from './App.vue';
import { client } from '@/client/services.gen';

import './assets/style.css';
import router from './router';
import Toast from 'vue-toastification';
import 'vue-toastification/dist/index.css';
import { createPinia } from 'pinia'

//if(import.meta.env.VITE_API_URL)
    //{
   //     client.client.OpenAPI.BASE = import.meta.env.VITE_API_URL;
   // }


client.setConfig({
    baseUrl: 'http://localhost:5171',
});
const pinia = createPinia()
const app = createApp(App);

app.use(pinia)
app.use(Toast);
app.use(router)
app.mount('#app');
