import { getUserUsername } from "./services.gen";


export async function checkUsernameInfo(usernameInput?: string){
    
    if (usernameInput == undefined){
        return;
    }

    const response =  await getUserUsername({query: {Username: usernameInput}})

    if (response.data == undefined) {
        return;
    }

    return response.data
    
    }