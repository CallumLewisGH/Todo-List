<style lang="css" scoped>
body {
  font-family: Arial, sans-serif;
  background-color: #333;
  color: azure;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  margin: 0;
}

.login-container {
  background-color: #444;
  border-radius: 2vh;
  padding: 4vh;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  width: 80%;
  max-width: 400px;
}

h2 {
  text-align: center;
  color: #fff;
}

input[type="text"], input[type="password"] {
  display: block;
  width: 100%;
  padding: 10px;
  margin: 10px 0;
  background-color: #6b6b6b;
  color: azure;
  border: 1px solid #494949;
  border-radius: 3vh;
  min-height: 4vh;
  text-indent: 1%;
}

button {
  width: 100%;
  padding: 10px;
  background-color: #5c5c5c;
  color: azure;
  border: none;
  border-radius: 3vh;
  font-size: 1rem;
  cursor: pointer;
}

button:hover {
  background-color: #7a7a7a;
}

.button-container {
  display: flex;
  justify-content: space-between;
}

.button-container button {
  width: 48%;
}
</style>

<template>
    <body>
        <div id="app" class="login-container">
        <h2>Login</h2>
        <input type="text" placeholder="Enter a Username..." v-model="usernameInput" style="min-width: 100%;">
        <input type="password" placeholder="Enter a Password..." v-model="passwordInput" style="min-width: 100%;">
        <div class="button-container">
            <button @click="usernameInput = '', passwordInput = '' ">Clear</button>
            <button @click="handleUserCheck(usernameInput, passwordInput)">Submit</button>
        </div>
        </div>
    </body>
</template>



<script setup lang="ts">
import { ref } from "vue"
import { UserDTO } from "@/client";
import { checkUserInfo } from "@/client/getUserByInput";
import { useToast } from "vue-toastification";
import "vue-toastification/dist/index.css";
import router from "@/router";
import { useUserStore } from "@/store";

const userStore = useUserStore();
const user = ref<UserDTO>();
const usernameInput = ref<string>();
const passwordInput = ref<string>();
const toast = useToast();

async function handleUserCheck(usernameInput?: string, passwordInput?: string){
  user.value = await checkUserInfo( usernameInput, passwordInput )
  if (user.value == undefined) {
    toast.error("Username and Password not found!")
    
  }

  else{
    toast.success("Username and Password Recognised!")
    userStore.setUserID(user.value.id?? 0)
    localStorage.setItem('UserId',JSON.stringify(user.value.id))

    router.push("todo")
  }

}

</script>

