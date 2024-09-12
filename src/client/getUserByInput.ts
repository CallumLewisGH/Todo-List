import { getUserInput } from "./services.gen";


export async function checkUserInfo(usernameInput?: string, passwordInput?: string){

    if (passwordInput == undefined || usernameInput == undefined){
        return;
    }

    const response =  await getUserInput({query: {Password: passwordInput, Username: usernameInput}})

    if (response.data == undefined) {
        return;
    }

    

    return response.data
    
    }