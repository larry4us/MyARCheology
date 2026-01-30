
# MyARCheology - Projeto de Residência AR/VR
Este repositório contém o projeto de desenvolvimento em Realidade Aumentada (AR) submetido para avaliação no processo de seleção da residência. O projeto explora o ciclo de desenvolvimento em AR, desde a detecção de superfícies até a interação com objetos virtuais.

## Organização do Repositório
O projeto foi desenvolvido seguindo boas práticas de engenharia de software como Git Workflow e Conventional commits.
O projeto está estruturado em **duas branches principais** para facilitar a avaliação da replicação técnica e das competências autorais:

- **main**: É a versão mais completa do projeto. Contém o projeto da trilha acrescido de funcionalidades extras e melhorias na experiência de usuário. Esta branch demonstra a aplicação prática de conhecimentos adicionais e exploração da ferramenta.

- **mainSemMelhorias**: É a replicação de todo o conteúdo desenvolvido durante a trilha da residência até a última aula. É o estado base do projeto conforme as instruções originais.

## Implementações Autorais
Além do conteúdo base da trilha, foram implementadas as seguintes melhorias na branch principal (_main_):

**Mecânica de Escavação**: Desenvolvimento de lógica para a descoberta de objetos, simulando uma experiência de arqueologia.

**Feedback Sonoro**: Implementação de sistema de áudio para ações específicas de interação e eventos na cena para aumentar a imersão da experiência.

**Refinamento de Materiais**: Aplicação de texturas nos modelos 3D para aumentar o realismo visual.

**Customização de Superfície:** Implementação de textura personalizada para os planos detectados pelo sistema de AR.

## Realização dos Desafios
Todos os desafios opcionais da trilha foram implementados na branch principal:

**Desafio 1 (Novas Interações)**: Adaptação e reutilização da lógica de interação para novas formas geométricas (cilindro e esfera).

**Desafio 2 (Personalização do Espaço)**: Expansão do armário virtual com a adição de "support cabinets", criando novos compartimentos e spots de posicionamento.

**Desafio 3 (Interface e Identidade)**: Integração de ícones e descrições dinâmicas via Scriptable Objects na UI, detalhando o artefato (Muiraquitã) após o escaneamento.

**Desafio 4 (Novas Animações)**: Implementação de animações decorativas em loop para elementos da cena, utilizando o Unity Animator para enriquecer a cena inicial.


### Requisitos para Execução
Unity 2022.3 ou superior.

Dispositivo móvel compatível com ARKit (iOS) ou ARCore (Android).

**Cenas localizadas no diretório: Assets/Scenes/ScanScene**