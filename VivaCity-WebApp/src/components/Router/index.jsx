import Layout from '../Layout';

import {
    createBrowserRouter,
    RouterProvider,
  } from 'react-router-dom';
  
  
  import Home from '../../pages/Home';
  import Login from '../../pages/Login';
  import Games from '../../pages/Games';
  
  const router = createBrowserRouter([
      {
      element: <Layout />,
          children: [
              {
                  path: "/",
                  element: <Home />,
              },
              {
                  path: "/login",
                  element: <Login />,
              },
              {
                  path: "/games",
                  element: <Games />,
              }
              
          ]
      }
  ]);
  
  export default function Router() {
      return (
          <RouterProvider router={router} />
      );
  }