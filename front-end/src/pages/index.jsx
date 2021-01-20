import Head from 'next/head';
import { useState } from 'react';
import { useRouter } from 'next/router';
import styles from '../styles/Home.module.css';
import { MainHeader, Container, Main, HeaderMenu, MenuItem } from '../styles/home';
import Login from './components/login';
import Avatar from './components/avatar';
import Logo from '../assets/logo-cinema.png';

export default function Home() {
  const [isLogedIn, setIsLogged] = useState(false);

  const router = useRouter();

  return (
    <>
      <Head>
        <title>Cine Ápice - Os melhores filmes estão aqui</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <MainHeader>
        <Container>
          <img src={Logo} alt="Created by Susana Bispo" />
          <HeaderMenu
            theme="dark"
            mode="horizontal"
            defaultSelectedKeys={['1']}
          >
            <MenuItem key="1" onClick={() => router.push('/')}>
              Filmes
            </MenuItem>
            <MenuItem key="2" onClick={() => router.push('/salas')}>
              Salas
            </MenuItem>
            <MenuItem key="3" onClick={() => router.push('/sessoes')}>
              Sessões
            </MenuItem>
          </HeaderMenu>
          {isLogedIn ? <Avatar>T</Avatar> : <Login>Login</Login>}
        </Container>
      </MainHeader>

      <Main>
        <main className={styles.main}>
          <h1 className={styles.title}>
            Welcome to <a href="https://nextjs.org">Next.js!</a>
          </h1>

          <p className={styles.description}>
            Get started by editing{' '}
            <code className={styles.code}>pages/index.js</code>
          </p>

          <div className={styles.grid}>
            <a href="https://nextjs.org/docs" className={styles.card}>
              <h3>Documentation &rarr;</h3>
              <p>Find in-depth information about Next.js features and API.</p>
            </a>

            <a href="https://nextjs.org/learn" className={styles.card}>
              <h3>Learn &rarr;</h3>
              <p>Learn about Next.js in an interactive course with quizzes!</p>
            </a>

            <a
              href="https://github.com/vercel/next.js/tree/master/examples"
              className={styles.card}
            >
              <h3>Examples &rarr;</h3>
              <p>Discover and deploy boilerplate example Next.js projects.</p>
            </a>

            <a
              href="https://vercel.com/import?filter=next.js&utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
              className={styles.card}
            >
              <h3>Deploy &rarr;</h3>
              <p>
                Instantly deploy your Next.js site to a public URL with Vercel.
              </p>
            </a>
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
