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

.home-container {
  background-color: #444;
  border-radius: 2vh;
  padding: 4vh;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  width: 80%;
  max-width: 400px;
  text-align: center;
}

h1 {
  font-size: 2.2rem;
  color: white;
  margin-bottom: 20px;
}

button {
  width: 100%;
  padding: 15px;
  margin: 10px 0;
  background-color: #5c5c5c;
  color: azure;
  border: none;
  border-radius: 3vh;
  font-size: 1.2rem;
  cursor: pointer;
}

button:hover {
  background-color: #7a7a7a;
}

.button-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.button-container button {
  margin: 10px 0;
}
</style>

<template>
    <body>
        <div id="app" class="home-container">
            <h1>Welcome!</h1>
            <div class="button-container">
                <button @click="">Log In</button>
                <button @click="">Sign Up</button>
            </div>
        </div>
    </body>
</template>

<script setup lang="ts">

</script>