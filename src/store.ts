import { defineStore } from 'pinia';


interface UserState {
  userID: number | undefined;
}

export const useUserStore = defineStore('user', {
  state: (): UserState => ({
    userID: undefined,
  }),

  actions: {
    setUserID(id: number) {
      this.userID = id;
    },
    clearUserID() {
      this.userID = undefined;
    }
  },

  getters: {
    getUserID: (state) => state.userID,
  }
});