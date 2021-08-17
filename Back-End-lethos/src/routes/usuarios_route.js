const express = require('express');
const router = express.Router();

const user=require('../controller/usuario_controller');

router.get('/usuario',user.GetUsuario);
router.post('/usuarioadd',user.AddUsuario);
router.get('/usuariodel/:id',user.DelUsuario);


module.exports = router;


