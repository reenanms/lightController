const char CommandSeparator = ':';
const char ParamsSeparator = ',';
const char EndChar = ';';


void setup()
{
  Serial.begin(9600);
}

String getCommandName(String rawCommand)
{

  return "";
}

void loop()
{
  /*
  Comandos suportados:
    ON [OUTPUT]
    OFF [OUTPUT]
  */
  
  if (Serial.available())
  {
    String rawCommand = Serial.readStringUntil(EndChar);
    Serial.print(rawCommand);
    Serial.print(EndChar);
  }
}
