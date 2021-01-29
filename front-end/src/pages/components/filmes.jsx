export default function Filmes({ items }) {
    return(
        <section>
            {items.map(filme => (
                <a href={`/filmes/${filme.id}`} style={{maxWidth: '300px'}}>
                    <img src={filme.image} alt="filme" style={{maxWidth: "inherit", maxHeight: "420px"}}/>
                    <p>{filme.title}</p>
                    <p>{filme.duration}</p>
                </a>
            ))}
        </section>
    )
}