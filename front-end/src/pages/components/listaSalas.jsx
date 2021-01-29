import {CrudLine, Operations} from '../../styles/components/crud';


export default function Salas({ items }) {



    return(
        <section>
            {items.map(sala => (
                <CrudLine>
                    <a href={`/salas/${sala.id}`}>{sala.name}</a>
                    <p>Assentos: {sala.qtnSeats}</p>
              </CrudLine>
            ))}
        </section>
    )
}