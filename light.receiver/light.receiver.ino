const char CommandSeparator = ':';
const char ParamsSeparator = ',';
const char EndChar = ';';

//const int port = 7;

typedef void (*FuncRun)(void);

struct Command {
   FuncRun Run;
   String Name;
   String Parameters[]; 
};

void turnOn(int port)
{
  pinMode(port, OUTPUT);
  digitalWrite(port, LOW);
}

void turnOff(int port)
{
  pinMode(port, OUTPUT);
  digitalWrite(port, HIGH);
}

void sendSerialCommand(String command)
{
  Serial.print(command);
  Serial.print(EndChar);
}

bool getParams(String rawCommand, int commandSeparatorIndex, int numberOfParams, String* outputParams)
{
  int afterIndex = commandSeparatorIndex;
  for(int i = 0; i < numberOfParams; i++)
  {
     int startIndex = afterIndex+1;
     afterIndex = rawCommand.indexOf(ParamsSeparator, afterIndex+1);
     //apenas o ultimo parametro esperado pode não ter o separador(",")
     if (afterIndex == -1 && i != numberOfParams-1) return false; 
     
     int endIndex = afterIndex != -1 ? afterIndex : rawCommand.length()-1;
     String param = rawCommand.substring(startIndex, endIndex+1);
     outputParams[i] = param;
  }

  return true;
}

void getCommand(String rawCommand)
{
  int commandSeparatorIndex = rawCommand.indexOf(CommandSeparator);
  String commandName = rawCommand.substring(0, commandSeparatorIndex);

  if (commandName ==  "ON")
  {
    String params[1];
    getParams(rawCommand, commandSeparatorIndex, 1, params);
    turnOn(7);
    sendSerialCommand("S:OK");
  }
  else if (commandName == "OFF")
  {
    String params[1];
    getParams(rawCommand, commandSeparatorIndex, 1, params);;
    turnOff(7);
    sendSerialCommand("S:OK");
  }
}

void setup()
{
  Serial.begin(9600);
}



void loop()
{
  /*
  Comandos suportados:
    ON:[OUTPUT_PORT_NUMBER]
    OFF:[OUTPUT_PORT_NUMBER]
  */
  
  if (Serial.available())
  {
    String rawCommand = Serial.readStringUntil(EndChar);
    
    //sendSerialCommand(rawCommand);
    getCommand(rawCommand);
  }
}
