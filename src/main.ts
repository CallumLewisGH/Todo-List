import { createApp } from 'vue';
import App from './App.vue';
import { client } from '@/client/services.gen';

import './assets/style.css';

import Toast from 'vue-toastification';
import 'vue-toastification/dist/index.css';


//if(import.meta.env.VITE_API_URL)
    //{
   //     client.client.OpenAPI.BASE = import.meta.env.VITE_API_URL;
   // }


client.setConfig({
    baseUrl: 'http://localhost:5171',
});

const app = createApp(App);
app.use(Toast);
app.mount('#app');
