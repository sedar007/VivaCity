import { useState, useEffect } from 'react';
import { TEInput } from "tw-elements-react";
import { useNavigate } from 'react-router-dom';
import { useLanguageContext } from "../../contexts/languageContext.jsx";
import '../../index.css';

import logo1 from "../../images/depositphotos_94218744-stock-illustration-house-in-a-village.jpg";
import logo2 from "../../images/la-maison-de-lumiere-concue-par-mbeam-studio-d-art-leger-maison-composee-de-murs-lumineux-un-jeu-multiforme-de-couleurs-et-de-lumiere-2hmwyx0.jpg";
import useUsers, {useUser} from "../../business/useUser.js";
import {canUserBeCreate, createUser, getUserByPseudo} from "../../business/users.js";
import useVillageId from "../../hooks/useVillageId.js";
import useVillageIdSetter from "../../hooks/useVillageIdSetter.js";
import useUsersSetter from "../../hooks/useUsersSetter.js";

// Tableau pour simuler les utilisateurs
let localUsers = [];

export default function Login() {
    const { t } = useLanguageContext();
    const [pseudo, setPseudo] = useState('');
    const [selectedUserId, setSelectedUserId] = useState('');
    const users = useUsers();
    const setUsers = useUsersSetter();
    const user = useUser(selectedUserId);



    const navigate = useNavigate();
    const [error, setError] = useState(null);



    useEffect(() => {
        if(!user)
            return;
        setPseudo(user.pseudo);
    }, [user]);

    const handlePseudoChange = (e) => {
        setPseudo(e.target.value);
    };

    const handleUserSelection = (e) => {
        const userId = e.target.value;
        setSelectedUserId(userId);
    };

    const submitForm = async(e) => {
        e.preventDefault();
        try{
            const us =  await getUserByPseudo(pseudo);
            if(us === null){
                setError('User not found');
                return;
            }
            connected(us);


        }
        catch (e) {
        setError(e.message);
    }
    };

    const connected = (user) => {
        localStorage.setItem('token', 'fake-token');
        localStorage.setItem('pseudo', user.pseudo);
        localStorage.setItem('idUser', user.id);
        setError('');
        setPseudo('');
        setSelectedUserId('');
        setUsers(user);
        navigate('/games');
    }

    const handleCreateUser = async() => {
        try {

            const canCreate = await canUserBeCreate(pseudo)
            if(!canCreate){
                setError('User Already Exist');
                return;
            }
            const create = await createUser(pseudo);

           connected(create);

        } catch (e) {
            setError(e.message);
        }
    };

    return (
        <section className="h-full bg-neutral-200 dark:bg-neutral-700">
            <div className="container h-full p-10">
                <span>{error}</span>
                <div className="g-6 flex h-full flex-wrap items-center justify-center text-neutral-800 dark:text-neutral-200">
                    <div className="w-full">
                        <div className="block rounded-lg bg-white shadow-lg dark:bg-neutral-800">
                            <div className="g-0 lg:flex lg:flex-wrap">
                                <div className="px-4 md:px-0 lg:w-6/12">
                                    <div className="md:mx-6 md:p-12">
                                        <div className="text-center">
                                            <img
                                                className="mx-auto w-48"
                                                src={logo1}
                                                alt="logo1"
                                            />
                                            <h4 className="mb-12 mt-1 pb-1 text-xl font-semibold">
                                                Welcome to Our Community VivaCity
                                            </h4>
                                        </div>

                                        <form onSubmit={submitForm}>
                                            <p className="mb-4">{t('User')}</p>
                                            <TEInput style={{border:"2px solid black"}}
                                                type="text"
                                                // label="Pseudo"
                                                className="mb-4"
                                                value={pseudo}
                                                onChange={handlePseudoChange}
                                                required
                                            ></TEInput>

                                            <div className="mt-10 mb-12 pb-1 pt-1 text-center">
                                                <button
                                                    className="mb-3 inline-block w-full rounded px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_rgba(0,0,0,0.2)] transition duration-150 ease-in-out hover:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:outline-none focus:ring-0 active:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)]"
                                                    type="submit"
                                                    style={{
                                                        background:
                                                            "linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593)",
                                                    }}
                                                >
                                                    {t('Login')}
                                                </button>
                                                <button
                                                    className="mb-3 inline-block w-full rounded px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_rgba(0,0,0,0.2)] transition duration-150 ease-in-out hover:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)] focus:outline-none focus:ring-0 active:shadow-[0_8px_9px_-4px_rgba(0,0,0,0.1),0_4px_18px_0_rgba(0,0,0,0.2)]"
                                                    type="button"
                                                    style={{
                                                        background:
                                                            "linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593)",
                                                    }}
                                                    onClick={handleCreateUser}
                                                >
                                                    {t('CreateUser')}
                                                </button>
                                            </div>

                                            <div className="mb-4">
                                                <select
                                                    onChange={handleUserSelection}
                                                    value={selectedUserId}
                                                    className="form-select"
                                                >
                                                    <option value="">{t('ChoiceUser')}</option>
                                                    {users.map(user => (
                                                        <option key={user.id} value={user.id}>
                                                            {user.pseudo}
                                                        </option>
                                                    ))}
                                                </select>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                                <div
                                    className="flex items-center rounded-b-lg lg:w-6/12 lg:rounded-r-lg lg:rounded-bl-none"
                                    style={{
                                        background:
                                            "linear-gradient(to right, #ee7724, #d8363a, #dd3675, #b44593)",
                                    }}
                                >
                                    <div className="px-4 py-6 text-white md:mx-6 md:p-12">
                                        <h4 className="mb-6 text-xl font-semibold">
                                            Join our community VivaCity
                                        </h4>
                                        <img
                                            className="image-home"
                                            src={logo2}
                                            alt="logo-comment"
                                        />
                                        <br/>
                                        <p className="text-sm">
                                            Bienvenue dans notre communauté de jeu pour les villages.
                                        </p>
                                        <p className="text-sm">
                                            Une expérience est à votre côté et vous allez y arriver à le faire.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}
