package groovy.scripts

import groovy.net.xmlrpc.*
import javax.security.auth.callback.CallbackHandler
import org.jivesoftware.smack.ConnectionConfiguration
import org.jivesoftware.smack.XMPPConnection
import org.jivesoftware.smack.packet.Message
import org.jivesoftware.smack.SASLAuthentication;
import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.MessageListener


def process=new ProcessBuilder("/opt/ejabberd/ejabberd-16.03/bin/ejabberdctl send_message chat admin@raspberrypi.local dani@raspberrypi.local 'Security' 'Someone rang your door bell while you were not at home'").redirectErrorStream(true).start()
process.inputStream.eachLine {println it}

ConnectionConfiguration config = new ConnectionConfiguration("raspberrypi.local", 5222,"raspberrypi.local")
connection = new XMPPConnection(config);

config.setDebuggerEnabled(true)
config.setSASLAuthenticationEnabled(true);

SASLAuthentication.supportSASLMechanism("PLAIN", 0)
print("Before")
connection.connect();
print("Connected")
//connection.login("activiti",null);
print("Loggedd in")
Chat chat = connection.getChatManager().createChat("dani", new MessageListener() {

             public void processMessage(Chat chat, Message message) {
                 // Print out any messages we get back to standard out.
                 System.out.println("Received message: " + message);
             }
         });
Message msg = new Message("dani@raspberrypi.local")
msg.sprintf("Test")

chat.sendMessage("Someone rang the bell while you weren't at home!")
//Message msg = new Message("dani", Message.Type.normal)
//msg.setBody("Someone rang the bell while you weren't at home!")
//connection.sendPacket(msg)
connection.disconnect()