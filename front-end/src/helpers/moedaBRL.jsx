export default function MoedaBrl(price){

return price.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'});
}