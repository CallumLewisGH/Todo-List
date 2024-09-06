<template>
  <div class="masterContainer">
    <component  :is="$route.meta.layout || 'div'">
      <router-view></router-view>
    </component>
  </div>
</template>

<script setup lang="ts">
</script>