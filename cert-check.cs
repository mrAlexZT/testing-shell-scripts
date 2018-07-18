import java.net.URL;
import javax.net.ssl.HttpsURLConnection;
import java.security.cert.X509Certificate;
import java.security.cert.Certificate;

var respCheck = checkCertificate("https://11111.demo.jelastic.com/");
if (respCheck.result != 0) {
	respCheck.step = 'checkCertificate';
	return respCheck;
}

function checkCertificate(url) {
	var res = [];
	var destinationURL = new URL(url);
	var conn = destinationURL.openConnection();
	conn.connect();
	var certs = conn.getServerCertificates();
	for (var i = 0; i < certs.length; i++) {
		var cert = certs[i];
		var issuer = cert.getIssuerDN().toString();
		if (issuer.indexOf("Fake LE") > -1) return {
			result: 0,
			message: "passed"
		}

	}
	return {
		result: 99,
		error: "Can't find LE certificate"
	};
}

