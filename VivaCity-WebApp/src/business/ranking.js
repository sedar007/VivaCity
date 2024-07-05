import {useEffect, useState} from "react";
import { API_URL } from '../../config';


async function _getRanking(){
    const res = await fetch(`${API_URL}Ranking`);

    if(res.ok)
        return await res.json();

    throw new Error('Failed to fetch ranking');
}

export  default async function getRanking(){
    return await _getRanking();
}