const express = require('express');
const router = express.Router();

const api=require('../controller/api_controller');

router.get('/apipersonajes',api.GetPersonaje);
router.get('/apiversiones',api.GetVersion);
router.get('/apipartes',api.GetPartes);
router.get('/apiaccesorios',api.GetAccesorio);
router.get('/apiemociones',api.GetEmocion);

module.exports = router;

