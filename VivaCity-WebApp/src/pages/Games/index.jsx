// eslint-disable-next-line no-unused-vars
import React, {useEffect} from 'react';
import Village from '../../components/Village'
import './index.css'
import {useNavigate} from "react-router-dom";

export default function Games() {
	const navigate = useNavigate();

	useEffect(() => {
		const token = localStorage.getItem('token');
		if (!token) {
			navigate('/login');
		}
	}, [navigate]);

	return (


				<Village name="Sunnydale" level=" 1" />







	);
}