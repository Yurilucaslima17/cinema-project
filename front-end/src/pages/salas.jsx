import Head from 'next/head';
import api from '../services/api';
import {CrudLine, Main} from '../styles/components/crud';
import ListaSalas from './components/listaSalas';
import MainHeader from './components/header';
import {PlusCircleOutlined} from '@ant-design/icons';

export default function Salas({salas}){
  
    return(
        <>
            <Head>
                <title>Cine Ápice - Os melhores filmes estão aqui</title>
                <link rel="icon" href="/favicon.ico" />
            </Head>

            <MainHeader/>

            <Main className="cinema">
              <ListaSalas items={salas}/>
            </Main>
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