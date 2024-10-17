import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import App from './App.tsx';
import './index.css';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
   <BrowserRouter>
      <HelmetProvider>
         <QueryClientProvider client={queryClient}>
            <App />
         </QueryClientProvider>
      </HelmetProvider>
   </BrowserRouter>
);
