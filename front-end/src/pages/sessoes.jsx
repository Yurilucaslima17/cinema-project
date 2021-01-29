import {PlusCircleOutlined} from '@ant-design/icons';
import Swal from 'sweetalert2';
import api from '../services/api';
import ListaSessoes from './components/listaSessoes';
import MainHeader from './components/header';
import {Main, AddContainer, Formulario} from '../styles/components/crud';
import Head from 'next/head';
import Form from 'antd/lib/form/Form';
import {Input, Button, Checkbox, Date} from 'antd';


export default function Sessoes({sessoes, filmes, salas}){

  function addForm(){

    const date = document.querySelector('#date').value
    const price = document.querySelector('#price').value
    const is3d = document.querySelector('#is3d').value
    const isOriginal = document.querySelector('#original').value
    const film = document.querySelector('#film').value
    const room = document.querySelector('#room').value
    if (!date || !price || !film || !room) {
        Swal.fire({title:`Please enter with all information`,
        icon: 'info'
      })
    }
    else{
    
      const data = {
      "date": date,
      "price": price,
      "is3d": is3d,
      "isOriginal": isOriginal,
      "film": filmes.find(element => element.id == film),
      "room": salas.find(element => element.id == room)
    }

    api.post('/api/sessoes', data);
  }
}

    return(
        <>
        <Head>

        </Head>

        <MainHeader/>

        <Main>
            <AddContainer>
              <PlusCircleOutlined onClick={addForm}/>
              <Formulario>
              <input type="datetime-local" id="date" name="date" placeholder="Date"/>
            <input type="number" id="price" name="price" placeholder="100.00"/>
            <label>
            3D
            <input type="checkbox" id="is3d" name="is3d" value="true"/>
            </label>
            <label>
            Áudio Original
            <input type="checkbox" id="original" name="isOriginal" value="true"/>
            </label>
            <label>
              Filme
            <select id="film" name="film">
              {filmes.map(filme =>(
                <option value={filme.id}>{filme.title}</option>
              ))}
            </select>
            </label>
            <label>
              Sala
            <select id="room" name="room">
              {salas.map(sala =>(
                <option value={sala.id}>{sala.name}</option>
              ))}
            </select>
            </label>
              </Formulario>
            </AddContainer>
            <ListaSessoes items={sessoes} />
        </Main>
        </>
    )
}

export async function getStaticProps() {
    const response = await api.get('/api/sessoes');
    const { data } = await response;
  
    const responseFilms = await api.get('/api/filmes');
    const data2 = await responseFilms.data;

    const responseRooms = await api.get('/api/salas');
    const data3 = await responseRooms.data;
    return {
      props: {
        sessoes: data,
        filmes: data2,
        salas: data3
      }
    }
  }