import {useEffect, useState} from "react";
import { API_URL } from '../../config';
const USER_API_URL = `${API_URL}Users`;

async function _getUserByPseudo(pseudo){
    try {
        const res = await fetch(`${USER_API_URL}/searchByName/${pseudo}`);

        if(!res.ok) {
            throw new Error(`Failed to fetch user with status code: ${res.status}`);
        }

        return await res.json();
    } catch (error) {
        console.error(error);
        throw error;
    }
}


async function _createUser(pseudo){
        const res = await fetch(`${USER_API_URL}`, {
            method: 'POST',
            headers: {
                'Content-Type' : 'application/json',
            },
            body : JSON.stringify({
                pseudo : pseudo
            })
        });

        if(!res.ok) {
            throw new Error(`Erreur lors de la création de l'utilisateur`);
        }

        const jsObjet = await res.json();
        console.log(jsObjet);
        return jsObjet;
}

async function _canCreateUser(pseudo){
    try {
        const res = await fetch(`${USER_API_URL}/searchByName/${pseudo}`);

        return res.status === 404;

    } catch (error) {
        return false;
    }
}

export async function getUserByPseudo(pseudo){
    try{
        const user = _getUserByPseudo(pseudo);
        if(user === null)
            throw new Error('User not found');
        return user;
    }
    catch (error) {
        throw error;
    }

}



export async function canUserBeCreate(pseudo){
   return _canCreateUser(pseudo);
}

export async function createUser(pseudo){
    return _createUser(pseudo);
}