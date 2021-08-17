const express = require('express');
const router = express.Router();

const acc=require('../controller/accesorio_controller');

router.get('/Accesorios',acc.GetAccesorio);
router.post('/accesorioadd',acc.DelAccesorio);
router.get('/accesoriodel/:id',acc.DelAccesorio);


module.exports = router;


