import Head from 'next/head';
import api from '..server/api';

export default function Salas(){
    return(
        <>
            <Head>
                <title>Cine Ápice - Os melhores filmes estão aqui</title>
                <link rel="icon" href="/favicon.ico" />
            </Head>

            <MainHeader/>

            <main>
                
            </main>
        </>
    )
}

export async function getStaticProps() {
    const response = await api.get('/api/salas');
    const { data } = await response;
  
    return {
      props: {
        salas: data,
      }
    }
  }