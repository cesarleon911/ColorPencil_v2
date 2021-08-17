const express = require('express');
const router = express.Router();

const perso=require('../controller/personajes_controller');

router.get('/Personajes',perso.GetPersonaje);
router.post('/personajeadd',perso.AddPersonaje);
router.get('/personajedel/:id',perso.DelPersonaje);


module.exports = router;


