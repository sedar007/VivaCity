import {useEffect, useState} from "react";
import { API_URL } from '../../config';

const USER_API_URL = `${API_URL}Users`;

async function getUsers(){
    const res = await fetch(`${USER_API_URL}`);

    if(res.ok)
        return await res.json();

    throw new Error('Failed to fetch users');
}

async function getUser(id){
    const res = await fetch(`${USER_API_URL}/${id}`);

    if(res.ok)
        return await res.json();

    throw new Error('Failed to fetch user');
}

export default function useUsers(){
    const [users, setUsers] = useState([]);

    useEffect(() => {
        async function getData(){
            console.log(await getUsers());
            setUsers(await getUsers());
        }
        getData();
    }, []);

    return users;
}

export function useUser(id){
    const [user, setUser] = useState(null);

    useEffect(() => {
        if(!id) return;
        async function getData(){
            setUser(await getUser(id));
        }
        getData();
    }, [id]);

    return user;
}