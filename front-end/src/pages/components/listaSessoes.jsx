import {PlusCircleOutlined, EditOutlined, DeleteOutlined} from '@ant-design/icons';
import Swal from 'sweetalert2';
import MoedaBrl from '../../helpers/moedaBRL';
import {CrudLine, Operations} from '../../styles/components/crud';
import api from '../../services/api';

export default function Sessoes({items}){

    function openDeleteForm(sessao, isTrue = false) {
        if(isTrue){
        Swal.fire({
          icon: 'question',
            title: 'Tem certeza que deseja apagar esta Sessão?',
                confirmButtonText: 'Apagar',
                cancelButtonText: 'Cancelar',
              }).then((result) => {
                  if(result.isConfirmed){
                      api.delete(`/api/sessoes/${sessao.id}`).then(response =>{
                          Swal.fire({
                              icon: 'success',
                              title: 'Sessão seletada com sucesso',
                              timer: 3000
                          })
                      }).catch(error =>{
                          Swal.fire({
                              icon: 'error',
                              title: 'Ocorreu um erro',
                              timer: 3000
                          })
                      })
                  }
              })
            }
    }

    return(
        <>
            <section>
                {items.map(sessao => (
                    <CrudLine>
                        <a href={`/filme/${sessao.film.id}`}>{sessao.film.title}</a>
                        <p>Data Exibição: {sessao.date}</p>
                        <p>Preço: {MoedaBrl(sessao.price)}</p>
                        <p>{sessao.is3d ? "3D": "2D"}</p>
                        <p>{sessao.isOriginal ? "Original": "Dublado"}</p>
                        <p>Duração: {sessao.film.duration}</p>
                        <Operations>
                            <DeleteOutlined onClick={() => openDeleteForm(sessao, true)}/>
                        </Operations>
                    </CrudLine>
                ))}
            </section>
            
        </>
    )
}

