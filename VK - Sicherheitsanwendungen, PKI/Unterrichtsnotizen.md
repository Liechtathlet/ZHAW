## Repetition
  - Wie viel Inhalt können mit einem 1024-Bit Schlüssel übermittelt werden? 1024-Bit.
  - Ist das Padding normiert? Ja, in einem RFC
  - Grösse Integer? 32- / 64-Bit begrenzt durch Architektur, BigInteger :arrow_right: Spezialbehandlung
  - Was ist ein qualifiziertes Zertifikat? Personenzertifikat

##Padding
Ist der Text kürzer als der Schlüssel braucht es immer zwingend ein Padding. Ansonsten ist die Sicherheit der Nachricht gefährdet (Füllzeichen).

$x = a + bx + cy$  
$a^x * a^y = a^{(x+y)}$  
$a^{a_0} * a^{bx} * a^{cy} = a^{a_0 + bx + cy} = a^x$  
$a_0 = 0 \implies a^{a_0} = 0$  
$(xy)^d \equiv x^d * y^d mod n$  
$C_1 ....C_2$  
$C = \prod C(M_i)^{e^i} mod n \rightarrow M = \prod M_i^{e_i} mod n$  


# ASN.1 [Abstract Syntax Notation No. 1]


Wichtig:
  - Basic Encoding Rules (BER)
  - Distinguished Encoding Rules (DER)

##Beschreibungsstruktur
###Module


  *Modulname* DEFINITIONS::=BEGIN
                            EXPORTS export liste
                            IMPORTS imports
                            ....



www.oid-info.com



Sequence: 30h --> Tag: 0011 0000
Universal: 00
Zusammengesetzt: 1
Sequence: 16

Tag-Value: 30-0B-03-03-00-0F-C1-....

Sequence of Seuquence: 30 - L - 30 - ....


## Objekt-Identifier
x x 40 + y
1x40 + 2 = 42




##Zertifikate
###Erzeugung
  - Werden oft bei CA erstellt.

**Ablauf:**  
  1. Person geht zur RA für die initiale Registrierung (Intermidär).  
  2. RA bestätigt Identität und leitet den Request der CA weiter.  
  3. ....  
  x. PKCS#12-Container geht zurück an die Person (geschützt mit PIN)  


##Aufbau
ID + Signatur $sS_{p_{CA}}(ID)$
ObjectIdentifier :arrow_right: Signaturtyp + Algorithmus

Subject: Enduser oder Sub-CA

#X.509 Zertifikate nach RFC 5280
Bestandteil X.500-Standards (Verzeichnisdienste), nicht immer optimale Lösungen, da bereits alt, Authentifizierungsstandard für Kommunikationsnetze, 3. Teil des Standards: Formate für digitale Zertifikate






#
##Repetition
Hauptbestandteile Zertifikat:
  - tbs
  - AlgID
  - Sig ($ sS_a(tbs) $)

Erweiterungen / Extensions: Standard / Privat

Auflösung Zertifikatspfad: Via AuthorityKeyIdentifier

CA Zertifikat: Basic constraints, critical, Key Usage: critical (True, sonst immer false)

Dokumentunterschreibung: Key Usage: Content commitment

Attribut CRL: CRLDistributionPoint

Qualifiziertes zertifikat: Nur für natürliche Personen

##Attributzertifikat
Erweiterung Zertifikat um weitere Attribute (z.B. auch zeitbegrenzt).
Keine Identifikation, sondern Autorisierung

Analog zu SAML im Web-Bereich

Attribute müssen als OID hinterlegt sein

###ASN1
objectDigestInfo:objectDigest: Hashwert Identifikationszertifikat


#Sperrlisten (CRL)
crlDistributionPoint: URL für Sperrliste  
Key-Attribut für Revokation: Seriennummer  
crlEntryExtension: Bezogen auf jedes Zertifikat  
crlExtensions: Extensions für CRL selbst
CRL: Nicht notwendig, wenn normal abgelaufen
CRL: Nur noch für kleinere CAs oder Sub-CAs, OCSP stattdessen

#Verzeichnisdienst (OCSP)
RFC2560, via HTTP oder LDAP, Request-Signatur: optional

**TBSRequest (n Requests)**
  * Request
    * CertID
    * hashAlgorithm
    * issuernamehash
    * issuerkeyhash ("AuthorityKeyIdentifier", Hash Public key von Issuer)
    * serialnumber
    * singleRequestExtension*

**OCSPResponse**
Immer signiert durch OCSP-Dienst

  * SingleResponse
    * CertID
      * hashAlgorithm
      * issuernamehash
      * issuerkeyHash
      * serialnumber
    * certStatus
    * thisUpdate
    * singleExtensions*

  * OCSPResponse (nicht signiert)
    * responseStatus (nicht optional, immer)
    * responseBytes (optional, Anfrage falsch, falsches Cert, Inhalt nur wenn Anfrage beantwortbar) :arrow_right: BasicOCSPResponse

  * BasicOCSPResponse
    * tbsResponseData (signiert)

#XCA
ZHAW-Root-CA - ZHAW-Sub-CA

##Root-CA
1. XCA starte
    1. DB alege. -> Kes Passwort setze
    1. Certificates
    1. New Certificate
        1. Create a self signed certificate with the serial (self signed bedeutet es ist ein Root Zertifikat
        1. Signature algorithm: SHA 1
        1. Subject
        1. Internal name: ZHAW-Root-CA
        1. countryName: CH
        1. stateOrProvinceName: Zuerich
        1. localityName: Zuerich
        1. organizationName: ZHAW
        1. organizationUnitName: Certificate Services
        1. commonName: zhaw-root-ca
        1. Generate a new key
        1. Create
        1. Key usage
        1. Certificate Sign
        1. CRL Sign
        1. Key usage -> Critical
        1. Extensions
        1. Type -> Certification Authority
        1. Path length: 2
            - Leer = Unendlich lang
        1. Critical
        1. Subject Key Identifier
        1. Authority Key Identifier
        1. Not after: 10 Jahre gültig
        1. CRL distribution point -> Edit -> Add -> Content setzen auf: http://crl.zhaw-CA.ch (gibt es aber nicht) -> Apply
        1. Finales OK

##Sub-CA
  * use this Certificate for signing: ZHAW-Root-CA
  * Subject
    * Generate a new key
    * Ausfüllen
  * Key usage
    * Critical
    * Certificate sign
    * CRL sign
  * Extended key usage
    * Not critical
    * OCSP signing
  * Extensions
    * Type Authority: Certification Authority
    * path length: 1, critical
    * subject key Identifier, authority key Identifier
    * Time range: kleiner als Root (5)
    * CRL distribution point (URI:http://crl.zhaw.ch/subca.crl)
    * OCSP (URI:http://ocsp.zhaw.ch/)
  * Export DER

##Enduser Zertifikat (EE-Cert)
  * New Certificate
    * Use this Certificate for signing: Sub-CA
    * SHA1
    * HTTP_client
    * Generate a new key
    * Subject (ZHAW-Mail)
    * Key usage:
      * Digital Signature
      * Key Encipherment
      * Data Encipherment
    * Extended key usage:
      * E-mail Protection
    * Extensions
      * End Entity
      * Path length (leer)
      * Subject Key Identifier
      * Authority key identifier
      * Time Range: 1 Year
      * Subject alternative name: email:brundan1@students.zhaw.ch
      * CRL distribution point (URI:http://crl.zhaw.ch/subca.crl)
      * OCSP (URI:http://ocsp.zhaw.ch/)
    * Export DER, PKCS12 (Private, Public, PW:DaniBrun), PKCS7 (with Chain, Public)


#Timestamp-Dienst
Parameter: Hash Dokument, Ein Dokument aufs Mal mit Timestamp signieren, n können zurück kommen.

#Hash
Kollisionsresistenz (Geburtstagsangriff), gleicher Hash für gleiche Eingabe,

##SHA-1
Bläcke ä 512 Bit, Padding beim letzten Block (falls notwendig) bis zu 448 Bits, 64 Bit für Bit-Länge der ursprünglichen Nachricht, Grenze $ 2^64$

  - Alle 512 Bit Blöcke in 16 32-Bit (Big Endian) unterteilen
  - Epansion der 16 32-Bit Worte auf 80 32-Bit Worte
  - Kompression über 4 Runden
  - Addition der Hash-Werte :arrow_right: Hash-Wert (160 Bit)

  #HMAC
  ##HMAC
  grössere Entropie  , bessere Kollisionsresistenz

    - Schlüssel-Länge (aufgepaddet mit 0)),
    - XOR mit ipad (Konstant)
    - + Nachricht
    - Hash-Wert
    - + Schlüssel XOR opad (Konstant)

#SSL
Je höher die Schicht, desto unsicherer


##Übung
Zertifizierungsanfrage (Public Key, Subject Information)

  - Neues Zertifikat zu abgelaufenem Zertifikat, Unterschreiben mit altem Private Key

~~~
openssl
req -nodes -new -newkey rsa:2048 -outform DER -out csr.der
./dumpasn1 al csr.der
~~~

  - -nodes: optional, Private Key wird auch in die csr.der geschrieben
##Protokollstack
Ziel / Fixpunkt: DNS-Name (localhost:1234/test), Schichten: 5, 6, 7, Daten über Schicht 5 als SSL-Record, SSL beinhaltet / verwendet nirgends IP-Adressen, nur DNS

**SSL/TLS Record Header:** Handshake noch unverschlüsselt
**Handshake:** Client bleibt anonym (Browser kein Zertifikat), Diffie-Hellmann: Nur wenn Client anonym, sonst nicht, sonst: immer gleicher Key, heute wird Ephemeral Diffie-Hellmann verwendet (DHE_DSS, DHE_RSA), EDH: Vorteil: immer neuer Session Key (auch wenn client gehackt), RSA: Session Key voll von Client abhängig

##Protokoll
  - hello_request (Aushandlung neuer Session, auch während laufender Kommunikation), Server zu Browser
  - client_hello (Beginn Aufbau SSL-Session)
  - Erweitertes client_hello
  - server_hello
  - Erweitertes server_hello
  - certificate (Zertifikat inkl. Chain)
  - server_key_exchange (bei RSA braucht es dies nicht, nur bei Diffie Hellmann und Diffie Hellmann Ephemeral)
  - certificate_request
  - server_hello_done
  - certificate_verify (Nur client, Bildung Signatur Client, keine Verifikation Zertifikat auf Client)
  - client_key_exchange
  - finished

##Alert Protokoll
Eigener Payload, kann auch während Chiffrierung kommen, innerhalb eines SSL-/ TLS-Records, Level: Warning, Fatal

##Application Data Protokoll
Record-Layer 5, Transport Anwendungsdaten ohne Betrachtung Inhalt

#Kryptografische Komponenten von SSL und TLS
###Schlüsselerzeugung
| | :arrow_right: Konkatenation

#IPsec
Je weiter oben im OSI-Modell, desto unsicherer

##Standardisierung
###IKE
Handshake / Initialisierung

##IPsec Protokolle
Kein Client / Server, beide gleichberechtigt, Multi-VPN möglich

###IPv6
Header: unter Umständen: verkettete Liste
Mask: Eingeführt wegen zu wenigen IP-Adressen, eigentlich nicht mehr notwendig

##Übertragungsmodi
Tunnel-Modus: 2 IP-Adresse: 1 Klartext, 1 Verschlüsselt, bei beiden ESP möglich
Transport-Modus: Nur 1 IP-Adresse

##Teilprotokolle
###Authentication Header
Authentifiziert (z.B. MAC), nicht asymmetrisch (zu langsam), Tunnel- und Transportmodus, nicht verschlüsselt

SPI: Security Parameter Index, analogie zu Cyphersuite, Aushandlung, Zuordnung Security Assoziation

###Encapsulating Security Payload
Verschlüsselt, Transport- und Tunnelmodues

####Einbindung ESP in IPv4 (Transportmode)
next: Verweis auf TCP-header innerhalb des Payloads

####Einbindung ESP in IPv4 (Tunnelmode)
next: Verweis auf IP (innere IP) im Payload

##IPsec Management
Security Association Database und Security Policy Database pro VPN-Receiver

###ISAKMP
Version egall, universell

##IKEv1
###Authentisierung
  - Variante 1: Via Signatur (explizit)
    - Nachricht 1
      - Header: IKE-Header (ISAKMP, S. 27), Next Payload
      - SA: Security Assoziation (als Payload, S. 30)
      - Proposal 1: Proposal Payload (Einleitung Parameter, S. 30, SPI enthalten)
      - Transform 1: Transform Payload (Parameter, S. 31)
    - Antwort 1
      - Header: ISAKMP-Header
      - SA: Auswahl SA
      - Proposal: Ausgewähltes Proposal
      - Transform: Ausgewählter Transform
    - Nachricht 2
      - Header: ""
      - KEi: Diffie-Hellmann-Parameter (3)
      - Nonce: Zufallszahl
      - Certificate Request: Optional
    - Antwort 2
      - Header: ""
      - KEr: Diffie-Hellmann-Parameter
      - Nonce
      - Certificate Request: optional
    - Nachricht 3
      - Header
      - Payload: Verschlüsselt (Diffie-Hellmann ist ausgetauscht)
        - IDi
        - Certificate: Optional
        - Signatur i (Authentifizierung)
    - Antwort 3
      -Header
      -Payload: Verschlüsselt
        - IDr
        - Certificate: Optional
        - Signatur r: (Authentifizierung)
  - Variante 2: Authentisierung mit Public Key Verschlüsselung (implizit)
    - Nachricht 1 und Antwort 1 analog
    - Nachricht 2
      - Header
      - KEi: Diffie-Hellmann-Parameter (3) für Session-Key
      - Hash(Certifikat): optional, Hash von Zertifikat
      - IDi: Verschlüsselt mit Public-Key von Responder
      - Ni: Verschlüsselt mit Public-Key von Responder
    - Antwort 2
      - Header
      - KEr: Diffie-Hellmann-Parameter für Session-Key
      - IDr: Verschlüsselt mit Public-Key von Initiator
      - Nr: Verschlüsselt mit Public-Key von Initiator
    - Nachricht 3
      - Header
      - Hash_i: Verschlüsselt mit Diffie-Hellmann / Session-Key
      - Hash_r: Verschlüsselt mit Diffie-Hellmann / Session-Key
  - Veriante 3: Pre-Shared Key
      - Nachricht / Antowrt 1 und 2: analog
      - Nachricht 3:
        - Header
        - KEi: Diffie-Hellmann (3)
        - Ni
      - Antwort 3:
          - Header
          - KEr: Diffie-Hellmann (3)
          - Nr
      - Nachricht 4:
          - Header
          - Hash: Identifikation (mit Shared-Secret)
      - Antwort 4:
          - Header
          - hash: Identifikation (mit Shared-Secret)

###Aggressive-Mode
Schneller (nur 3 Nachrichten für Etablierung) und unsicherer, "sinnvoll" bei variablen / dynamischen IP-Adressen
  - Nachricht 1 und Nachricht 2 verkettet & zusammengefasst
  - Antwort 1: Antwort 1, 2 & 3 verketten & zusammengefasst
  - Nachricht 2

Gleiche Modes (Variante 1, 2 und 3 für Aggressive Mode), Variante 3 (Pre-Shared) im Aggressive-mode nicht verwenden! -> Knackbar


##IKE Quick Mode
IPsec-Schlüsselaustausch, anschliessend alles verschlüsselt (Key-Exchange bereits stattgefunden), braucht keine Authentisierung mehr, Wesentlichster Punkt: Austausch neues Key-Material, mit PFS oder ohne

##NAT-Traversal
###NAT/PAT und IPsec
NAT: Adress-Übersetzung (Kein Subnetz!), PAT: Port-Übersetzung, NAPT: Beides Zusammen

  - NAT: Tunnelmode funktioniert, Transportmode funktioniert nicht (AH: Problem MAC, nur ein IP-Header, wenn transferiert -> MAC stimmt nicht mehr)

##UDP-Einkapselung
Kapselung von IKE- und IPSec-ESP-Paketen: ISAKMP und Payload müssen gekapselt werden, Unterscheidung, nur ESP mit Transport- und Tunnelmode, AH läuft nicht

  - NAT-T: UDP Encapsulated ESP Header format
  - NAT-ESP Marker: IKE Header Format für Port 4500
  - NAT-T: ESP Transportmodus
  - NAT-Traversal: EsP Tunnelmodus
  - NAT-Keepalive Paket

###NAT-T
Vendor-ID: Hashwert von "RFC 3947" aka "Ich kann NAT-T", NAT-Discovery Payload, Port: Meist 500 UDP am Anfang,

**IKE-Main-Mode:**
    - Nachricht 1:
      - Header: ISKAMP
      - SA: Security Assoziation
      - Vendor-ID (Initiator -> Responder, ich kann NAT-Traversal)
    - Antwort 1:
      - Angabe eines neuen Ports für Zukunft
      - Header, SA, Vendor-ID
    - Nachricht 2:
      - Header, Diffie-Hellmann, Ni
      - NAT-D(r): IP / Port von Gegenseite  
        Stimmt überein: Kein NAT, sonst Keepalive-Pakets senden damit der Router den Eintrag in der Tabaelle behält.
      - NAT-D(i): Eigene IP / Port
    - Antwort 2:
      - Header, Diffie-Hellmann, Nr
      - NAT-D(r), NAT-D(l) -> Check off NAT-Fähig)
    - Nachricht 3:
      - Non-ESP-M, Header (ISAKMP), ID(i), Cert, Sig(i)
    - Antwort 3:
      - Non-ESP-M, Header, ID(r), Cert, Sig(r)

**NAT-T: IKE Aggressive Mode:**
Analog

**NAT-T: IKE Quickmode für ESP Transport-Mode**
NAT-OA-Payload: Original IP-Adresse, Quickmode bevor ESP Transport-Mode

##Internet Key Exchange Protocol Version 2 (IKEv2)
Init, Authentifizierung, Mehrere Kanäle auf gleicher Authentifizierung (Childs, ähnlich Quick-Mode), Informationsautschausch separat  

###IKE_SA_INIT
Cookies gegen DOS-Attacken  
Phase 1
  - Nachricht 1: (Keine Authentifizierung)
    - ISAKMP-Header
    - Security Assoziation
    - Diffie-Hellmann
    - Nonce
  - Antwort 1:
    - ISAKMP-Header
    - Security Assoziation
    - Diffie-Hellmann
    - Nonce
    - Cert (optional)

###IKE_AUTH
Phase 2, Alles verschlüsselt, aber noch nicht authentifiziert
  - Nachricht 1
    - ISAKMP-Header
    - IDi
    - Cert: optional
    - Cert-Req: optional
    - IDr: optional
    - AUTH: Authentisierungs-Information
    - SAi2: Ausgehandelte SA, Bestätigung
    - TSi: Traffic-Selektoren
    - TSr: Traffic-Selektoren
  - Antwort 1
    - ISAKMP-Header
    - IDr
    - Cert: optional
    - AUTH
    - SAr2
    - TSi: Anpassbar vom Responder
    - TSr: Anpassbar von Responder

###CREATE_CHILD_SA
Nochmals Diffie-Hellmann, Sitzungsschlüssel, Pro Child: Nachricht / Schritt 3
