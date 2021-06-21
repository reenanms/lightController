# Light Controller
Light Controller é um projeto de exemplo de como controlar uma lâmpada via terminal e protocolo serial


## O protocolo
O protocolo é baseado em conexão serial onde um microcontrolador trabalha como servidor e troca mensagens com uma máquina cliente através da serial.
A troca de mensagens funciona da seguinte maneira:
-O cliente faz uma solicitação (request) para o microcontrolador (servidor);
-O servidor processa a solicitação;
-O servidor responde (response) o resultado do processamento da solicitação.

![Request e response](requestResponse.png)

### Mensagem de request
As mensagens de request possuem o seguinte modelo:
```
[COMANDO]:[PARAM_0],[PARAM_1],...,[PARAM_N];
```

Onde:
- COMANDO: é nome do comando a ser executado;
- PARAM_*: parâmetro de entrada do comando (número de parâmetros varia de acordo com o comando).

Importante:
- O carácter ponto e vírgula (";") determina o fim do comando;
- O carácter dois pontos (":") separa o nome do comando dos parametros;
- O carácter vírgula (",") determina a separação entre os parametros do comando.


### Mensagem de response
As mensagens de response possuem o seguinte modelo:
```
[STATUS]:[MENSAGEM];
```

Onde:
- STATUS: é o status do processamento do request: S para sucesso ou E para erro;
- MENSAGEM: mensagem com informações do status.

Importante:
- O carácter ponto e vírgula (";") determina o fim do comando;
- O carácter dois pontos (":") separa o status da mensagem.

### Lista de comandos possíveis:
```
ON:[NumeroPorta];
 ```
Comando para ligar a saída recebida por parâmetro.
Exemplo ligando saída 7: ON:7;

![Ligando saída 7](CodeSendingCommandON.gif)

```
 OFF:[NumeroPorta];
 ```
Comando para desligar a saída recebida por parâmetro.
Exemplo desligando saída 7: OFF:7;

![Desligando saída 7](CodeSendingCommandOFF.gif)

```
 GET:[NumeroPorta];
 ```
Comando para retornar o status de uma saída recebida por parâmetro. Sendo 1 ligado e 0 desligado.
Exemplo solicitação da saída 7: GET:7;
Resposta: S:1; 

 ```
 GETALL:;
 ```
Comando para retornar o status de todas as saídas e seus status.
Exemplo solicitação das saídas: GETALL:;
Resposta com a saida 7 e 8 desligadas: S:7=0,8=0; 

## Interface de linha de comando (CLI)
Uma das maneiras de usar o protocolo é utilizar a interface de linha de comando (CLI). Ela abstrai o protocolo e disponibiliza para o usuário os comandos de forma mais amigável.

![CLI](CLI.gif)

### Lista de comandos
- help
- turnOn [NumeroPorta]
- turnOff [NumeroPorta]
- get [NumeroPorta]
- getAll

## Interface web (Servidor rest + web page)
Uma das maneiras de usar o protocolo é utilizar vir uma página web. Ela abstrai o protocolo e disponibiliza para o usuário uma usabilidade muito simples.

![web](web.gif)

## Implementação com Arduino
A implementação com Arduino é super simples, basta utulizar um módulo relé, o código da pasta Light.Receiver e montar o circuito conforme o exemplo abaixo:

![Esquema com Arduino](ArduinoSchema.png)

Exemplo de funcionamento:

![Exemplo em Arduino](ArduinoSample.gif)

## Referências
- https://www.embarcados.com.br/arduino-comunicacao-serial/
- https://www.filipeflop.com/blog/controle-modulo-rele-arduino/
- https://getbootstrap.com/docs/4.0/components/input-group/
- https://blog.logrocket.com/vue-typescript-tutorial-examples/
- https://www.youtube.com/watch?v=TSX_hMfL13U&list=PLQCmSnNFVYnTiC-pPY0SySbf-ZNGBwnaG
