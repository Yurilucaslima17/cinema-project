import Head from 'next/head';
import { useState } from 'react';
import { useRouter } from 'next/router';
import styles from '../styles/Home.module.css';
import { Main } from '../styles/home';
import MainHeader from './components/header';
import Filmes from './components/filmes';
import api from '../services/api';

export default function Home({ filmes }) {
  const [isLogedIn, setIsLogged] = useState(false);

  const router = useRouter();

  return (
    <>
      <Head>
        <title>Cine Ápice - Os melhores filmes estão aqui</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <MainHeader/>

      <Main>
        <main className={styles.main}>
          <h1 className={styles.title}>
            Bem-vindo ao Cine Ápice
          </h1>

          <div className={styles.grid}>
            <Filmes items={filmes}/>
          </div>
        </main>
      </Main>

      <footer className={styles.footer}>
        <a
          href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
          target="_blank"
          rel="noopener noreferrer"
        >
          Powered by{' '}
          <img src="/vercel.svg" alt="Vercel Logo" className={styles.logo} />
        </a>
      </footer>
    </>
  );
}

export async function getStaticProps() {
  const response = await api.get('/api/filmes');
  const { data } = await response;

  return {
    props: {
      filmes: data,
    }
  }
}