// eslint-disable-next-line no-unused-vars
import React, {useEffect, useState} from 'react';
import Village from '../../components/Village'
import './index.css'
import {useNavigate} from "react-router-dom";
import useVillage from "../../hooks/useVillage.js";
import useVillageSetter from "../../hooks/useVillageSetter.js";
import {getVillageByUser, getVillagesByUser} from "../../business/villages.js";



export default function Games() {
	const navigate = useNavigate();

	useEffect(() => {
		const token = localStorage.getItem('token');
		if (!token) {
			navigate('/login');
		}
	}, [navigate]);

	const village = useVillage();
	const setVillage = useVillageSetter();
	const [t, setT] = useState(null);






	const v =  (id) => {
		return  ;

	}
	useEffect(async() => {
		await getVillageByUser(village).then((t) => {
			setT(t);
		}).catch((error) => {});


        }, [village]);



	if(!t)
		return ;
	console.log("ttttt")
	console.log(t);
	console.log("ttttt")

	/*useEffect(() => {
		document.title = `Clics ${village}`;
	}, [village]); */





	/*const village = useVillage();
	const setVillage = useVillageSetter()*/




	/*const getVillages = async () => {
		const villags = await getVillagesByUser(localStorage.getItem('idUser'));
		console.log(villags);
		return villags;
	}


	const villages = getVillages(); */




	//console.log(villags);

	return (
		<div className="games-container">




			<div className="vill">
				<Village village = {t} />








	);
}