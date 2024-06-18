import Layout from '../Layout';

import {
    createBrowserRouter,
    RouterProvider,
  } from 'react-router-dom';
  
  
  import Home from '../Home';
  import Login from '../Login';
  import Games from '../Games';
  
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