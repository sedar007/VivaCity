import Footer from '../../components/Footer/index.jsx';
import Header from '../../components/Header/index.jsx';
import { Link, Outlet, useNavigate } from 'react-router-dom';
import Home from '../Home/index.jsx';
import {useEffect} from "react";

export default function LogOut() {
	const navigate = useNavigate();

	useEffect(() => {
		localStorage.clear();
		sessionStorage.clear();
		navigate('/login');
	}, [navigate]);

	return null;
}