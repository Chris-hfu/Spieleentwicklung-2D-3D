<?php
	$json = json_encode($_REQUEST);
	$fileSave = fopen("highscore.txt","w+") or die("Can't create highscore.txt");
	fwrite($fileSave,$json);
	fclose($filesave);
	print($json);
?>