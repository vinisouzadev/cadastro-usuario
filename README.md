# Autenticação e Autorização de usuários 
Este projeto fullstack de estudo trabalha com back-end em Minimal API e o front-end utilizando MudBlazor além de um projeto que intermedia os dois anteriores. A seguir, confira as especificidades de cada um:

* API: Foi utilizado minimal API, criando uma interface específica de mapeamento de endpoint, dividindo o projeto em uma classe de mapeamento de grupos endpoints,
uma implementação do mapeamento de endpoints e dentro dessa implementação há um método de chamada dos handlers, além do próprio handler.
Apesar de ter sido utilizado repositórios e serviços, foi muito trabalhado os recursos do Identity no projeto, personalizando classes e recriando endpoints da ferramente
para melhor se adequar as necessidades do projeto.

* Core: Projeto dedicado a criar classes e interfaces que podem ser compartilhadas entre o client-side e server-side, como requests, responses, interface de handler, etc.

* Front: O front foi construído com MudBlazor, implementando rotas de visualização com base em autorização e autenticação, além de implementar o provedor de autenticação através de claims
e uso de cookies para armazenar o estado do cliente.
