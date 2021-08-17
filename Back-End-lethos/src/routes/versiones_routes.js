const express = require('express');
const router = express.Router();

const vers=require('../controller/versiones_controller');

router.get('/Versiones',vers.GetVersion);
router.post('/versionadd',vers.AddVersion);
router.get('/versiondel/:id',vers.DelVersiones);


module.exports = router;


