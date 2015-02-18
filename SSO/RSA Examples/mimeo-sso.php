<?php
include('Crypt/RSA_XML.php');


$firstname = 'test'; //enc
$lastname = 'user';  //enc
$email = 'user@email.com';   //enc
$company_id = 'E212F625-365D-4682-8E6E-E01D42B4053D'; //no enc
$organization_id = '4E25B2DC-AC4C-41C7-A00F-856B2341C39B';
$company_name = 'my-company'; //enc
$authmarketplaceurl = 'company-sso';
$version = '2.0';
$redirect_url = 'https://marketplace.sandbox.mimeo.com/company-sso';
$error = 'http://google.com';
$mp_url = 'company-sso';
$customId='';
$initialCredit='';
$encryptedUserData='';

$rsa = new Crypt_RSA_XML();
$rsa->loadKeyFromXML("<RSAKeyValue><Modulus>pyFLk6GgRhEH00CdXRwsX9GcmaZuqQOo53pjOE/TBIO7QheFkAHAYsOLL6KJQQAekl/QKPehUVY9HgS6e+wnJzjuS03hKtvUqTNixDMQV6Mfr+YWZW2mSodcQd9MC9NT8Pyi11eBDogTQelkMoyq5gtJ4odpVd+d/oNCkAFsnJE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); 

$rsa->setEncryptionMode(CRYPT_RSA_SIGNATURE_PKCS1);


$firstname_e = base64_encode(($rsa->encrypt($firstname))); //ok
$lastname_e = base64_encode(($rsa->encrypt($lastname))); //ok
$email_e = base64_encode(($rsa->encrypt($email))); //ok
$company_name_e = base64_encode(($rsa->encrypt($company_name))); //ok
$organization_id_e = base64_encode(($rsa->encrypt($organization_id))); //ok
$customId_e = base64_encode(($rsa->encrypt($customId)));
$initialCredit_e = base64_encode(($rsa->encrypt($initialCredit)));
$encryptedUserData_e = base64_encode(($rsa->encrypt($encryptedUserData)));
 
 echo "<br>";


echo "<form method=\"post\" action=\"https://my.sandbox.mimeo.com/sso/authenticate.ashx\">\n"; 
echo "<input type=\"hidden\" name=\"firstName\" value=\"$firstname_e\" />\n";
echo "<input type=\"hidden\" name=\"lastName\" value=\"$lastname_e\" />\n";
echo "<input type=\"hidden\" name=\"email\" value=\"$email_e\" />\n";
echo "<input type=\"hidden\" name=\"companyId\" value=\"$company_id\" />\n";
echo "<input type=\"hidden\" name=\"authorizedMarketPlaceUrl\" value=\"$authmarketplaceurl\" />\n";
echo "<input type=\"hidden\" name=\"ssoVersion\" value=\"$version\" />\n";
echo "<input type=\"hidden\" name=\"redirectUrl\" value=\"$redirect_url\" />\n";
echo "<input type=\"hidden\" name=\"errorUrl\" value=\"$error\" />\n";
echo "<input type=\"hidden\" name=\"customId\" value=\"$customId_e\" />\n";
echo "<input type=\"hidden\" name=\"initialCredit\" value=\"$initialCredit_e\" />\n";
echo "<input type=\"hidden\" name=\"organizationId\" value=\"$organization_id_e\" />\n";
echo "<input type=\"hidden\" name=\"companyName\" value=\"$company_name_e\" />\n";
echo "<input type=\"hidden\" name=\"authorizedMarketPlaceUrl\" value=\"$mp_url\" />\n";
echo "   <input type=\"submit\" value=\"Submit\" />\n"; 
echo " </form>\n";


/**
$opts = array('http' =>
    array(
        'method'  => 'POST',

        'content' => $postdata
    )	 'firstname= > $lkajsl
    _post
);

$context = stream_context_create($opts);

$result = file_get_contents('https://my.sandbox.mimeo.com/sso/authenticate.ashx', false, $context); // post to 3dream
echo $result;
**/


?>
