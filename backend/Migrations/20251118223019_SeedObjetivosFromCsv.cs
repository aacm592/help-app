using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedObjetivosFromCsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ObjetivosEducativos",
                columns: new[] { "Id", "AreaCrecimientoId", "Descripcion", "EtapaProgresionId" },
                values: new object[,]
                {
                    { 1, 3, "Me doy cuenta y puedo hablar de las cosas que me atemorizan.", 3 },
                    { 2, 3, "Me doy cuenta por que reacciono de la manera en que a veces lo hago.", 3 },
                    { 3, 3, "Busco apoyo en mi patrulla cuando estoy triste o algo me confunde.", 3 },
                    { 4, 3, "Escucho las opiniones de los demás y si no estoy de acuerdo lo digo con respeto.", 3 },
                    { 5, 3, "Soy capaz de decir que no cuando creo que algo es incorrecto.", 3 },
                    { 6, 3, "Me gusta querer y que me quieran.", 3 },
                    { 7, 3, "Soy leal con mis amigos sin dejar de lado o tratar mal a quienes no lo son.", 3 },
                    { 8, 3, "Me intereso por los demás y soy generoso.", 3 },
                    { 9, 3, "Me informo adecuadamente sobre lo que significa ser hombre y ser mujer.", 3 },
                    { 10, 3, "Entiendo que la sexualidad humana esta unida al amor.", 3 },
                    { 11, 3, "Comparto por igual con mis hermanas y hermanos las tareas que nos piden en casa.", 3 },
                    { 12, 3, "Me gusta hacer cosas con mi familia y ayudo en lo que me piden para organizarlas.", 3 },
                    { 13, 3, "Le cuento a mi familia lo que hacemos en los scouts y trato que ellos participen en las actividades a las que son invitados.", 3 },
                    { 14, 2, "Me gusta participar en actividades que me ayudan a conocerme.", 3 },
                    { 15, 2, "Escucho las críticas que me hacen los demás y reflexiono sobre ellas.", 3 },
                    { 16, 2, "Sé que puedo ser cada día mejor.", 3 },
                    { 17, 2, "Me propongo metas para ser mejor.", 3 },
                    { 18, 2, "Hago cosas que me ayudan a cumplir mis metas.", 3 },
                    { 19, 2, "Me ofrezco para ayudar en mi patrulla, en mi tropa y en mi casa.", 3 },
                    { 20, 2, "Conozco y comprendo la Ley y la Promesa Scout.", 3 },
                    { 21, 2, "Se lo que significa ser leal.", 3 },
                    { 22, 2, "He prometido esforzarme por vivir la Ley y la Promesa Scout.", 3 },
                    { 23, 2, "Trato de ser leal con lo que creo, conmigo mismo y con los demás.", 3 },
                    { 24, 2, "Participo en actividades que muestran la importancia de actuar con lealtad.", 3 },
                    { 25, 2, "Enfrento y resuelvo mis dificultades con alegría.", 3 },
                    { 26, 2, "Contribuyo al ambiente de alegría de mi Tropa.", 3 },
                    { 27, 2, "Expreso mi alegría sin burlarme de los demás.", 3 },
                    { 28, 2, "Aprecio los consejos que me dan en mi patrulla.", 3 },
                    { 29, 2, "Respeto las decisiones tomadas en mi patrulla, aun cuando piense distinto.", 3 },
                    { 30, 1, "Participo en actividades que ayudan a mantener mi cuerpo fuerte y sano.", 3 },
                    { 31, 1, "Me doy cuenta de los cambios que se están produciendo en mi cuerpo.", 3 },
                    { 32, 1, "Se lo que puedo y no puedo hacer con mi cuerpo.", 3 },
                    { 33, 1, "Trato de evitar situaciones que puedan dañar mi salud y la de mis compañeros.", 3 },
                    { 34, 1, "Trato de no ser agresivo en juegos y otras actividades.", 3 },
                    { 35, 1, "Me preocupo por mi aspecto personal y porque mi cuerpo esté limpio.", 3 },
                    { 36, 1, "Ayudo en ordenar y limpiar mi casa y los lugares en que estudio y juego.", 3 },
                    { 37, 1, "Como los alimentos que me ayudan a crecer y lo hago a las horas adecuadas.", 3 },
                    { 38, 1, "Sé por qué es importante la limpieza al preparar y comer los alimentos.", 3 },
                    { 39, 1, "Le dedico al estudio el tiempo necesario.", 3 },
                    { 40, 1, "Me gusta participar en distintas actividades recreativas.", 3 },
                    { 41, 1, "Practico regularmente un deporte.", 3 },
                    { 42, 1, "Conozco y practico diferentes juegos y respeto sus reglas.", 3 },
                    { 43, 1, "Participo en los juegos, excursiones y campamentos que organiza mi tropa.", 3 },
                    { 44, 6, "Aprendo cosas nuevas además de las que me enseñan en la escuela.", 3 },
                    { 45, 6, "Me intereso por conocer mas de lo que pasa a mi alrededor.", 3 },
                    { 46, 6, "Busco mis propias lecturas y puedo relacionarlas con las cosas que me pasan.", 3 },
                    { 47, 6, "Doy mi opinión sobre las cosas que me pasan.", 3 },
                    { 48, 6, "Ayudo en la preparación de los temas que discutimos en mi patrulla y tropa.", 3 },
                    { 49, 6, "Participo en la organización de las excursiones de mi patrulla y tropa.", 3 },
                    { 50, 6, "Perfecciono mis habilidades manuales.", 3 },
                    { 51, 6, "Conozco y uso algunas técnicas de campismo y pionerismo.", 3 },
                    { 52, 6, "Elijo y completo una especialidad.", 3 },
                    { 53, 6, "Uso las especialidades que he adquirido para resolver problemas cotidianos.", 3 },
                    { 54, 6, "Participo con entusiasmo en las actividades artísticas de mi Unidad.", 3 },
                    { 55, 6, "Expreso mis pensamientos y experiencias en el Libro de Oro de la patrulla.", 3 },
                    { 56, 6, "Conozco diferentes técnicas de comunicación y se utilizar alguna de ellas.", 3 },
                    { 57, 6, "Puedo identificar las principales partes de un problema.", 3 },
                    { 58, 5, "Reflexiono con mi patrulla cuando hacemos excursiones o campamentos.", 3 },
                    { 59, 5, "Escucho a los demás y aprendo de ellos.", 3 },
                    { 60, 5, "Conozco los fundamentos de mi fe.", 3 },
                    { 61, 5, "Soy constante en los compromisos que he asumido con mi religión.", 3 },
                    { 62, 5, "Asumo tareas en las celebraciones religiosas que hacemos en mi tropa.", 3 },
                    { 63, 5, "Me gusta rezar y trato de hacerlo todos los días.", 3 },
                    { 64, 5, "Siempre encuentro en lo que hago, razones para pedir y dar gracias a Dios.", 3 },
                    { 65, 5, "Rezo habitualmente con mi patrulla.", 3 },
                    { 66, 5, "Trato de vivir las enseñanzas de mi fe en todo lo que hago.", 3 },
                    { 67, 5, "Entiendo por que mi fe me pide que ayude a los demás.", 3 },
                    { 68, 5, "Se cuales son las principales religiones que hay en mi país.", 3 },
                    { 69, 5, "Comparto con todas las personas, sean o no de mi religión.", 3 },
                    { 70, 4, "Procuro que respetemos a nuestros compañeros cualquiera sea su forma de ser.", 3 },
                    { 71, 4, "Cumplo los compromisos que asumo.", 3 },
                    { 72, 4, "Converso con mi patrulla sobre los derechos humanos.", 3 },
                    { 73, 4, "Entiendo cuales son mis responsabilidades cuando tengo un cargo.", 3 },
                    { 74, 4, "Participo en las elecciones de mi patrulla y coopero con los que son elegidos.", 3 },
                    { 75, 4, "Trabajo con los demás para lograr las metas que nos hemos propuesto.", 3 },
                    { 76, 4, "Digo mi opinión cuando establecemos normas en mi patrulla, entre mis amigos o en mi escuela.", 3 },
                    { 77, 4, "Conozco y respeto las principales normas de convivencia.", 3 },
                    { 78, 4, "Se que hacen los bomberos, la policía, los hospitales, el municipio y los otros servicios públicos de mi comunidad.", 3 },
                    { 79, 4, "Trato de realizar una buena acción todos los días.", 3 },
                    { 80, 4, "Participo en las actividades de servicio que organiza mi patrulla y tropa.", 3 },
                    { 81, 4, "Conozco las distintas realidades sociales del lugar en que vivo.", 3 },
                    { 82, 4, "Conozco los principales productos propios de la cultura de mi país.", 3 },
                    { 83, 4, "Me gusta sentirme parte de la cultura de mi país.", 3 },
                    { 84, 4, "Participo en las actividades que muestran la cultura de mi país.", 3 },
                    { 85, 4, "Conozco los principales símbolos del Movimiento Scout.", 3 },
                    { 86, 4, "Participo en actividades organizadas por mi Asociación.", 3 },
                    { 87, 4, "Conozco las principales culturales originarias de América.", 3 },
                    { 88, 4, "Participo en actividades y talleres en que aprendo la importancia de la comprensión internacional y la paz.", 3 },
                    { 89, 4, "Conozco los diferentes ecosistemas de mi país.", 3 },
                    { 90, 4, "Ayudo en la limpieza y el mejoramiento de los lugares en que paseo y acampo.", 3 },
                    { 91, 4, "He participado con mi patrulla en la mantención de un huerto productivo u otro proyecto similar.", 3 },
                    { 92, 3, "Trato de dominar mis reacciones, aun en situaciones difíciles o inesperadas.", 4 },
                    { 93, 3, "Se que es normal que a veces prefiera la soledad, o no me atreva a hacer algo, o sienta inseguridad o rabia; y trato de manejar estos sentimientos.", 4 },
                    { 94, 3, "Comparto mis sentimientos y emociones con mi patrulla.", 4 },
                    { 95, 3, "Digo lo que pienso con respeto hacia los demás.", 4 },
                    { 96, 3, "Mantengo mi opinión cuando estoy convencido que es correcta.", 4 },
                    { 97, 3, "Aprecio a mis amigos y amigas y no me enojo con ellos por cualquier cosa.", 4 },
                    { 98, 3, "Entiendo la importancia del amor en mi vida.", 4 },
                    { 99, 3, "Estoy siempre dispuesto a ayudar a mis compañeros de patrulla.", 4 },
                    { 100, 3, "Aprecio a las personas por lo que son.", 4 },
                    { 101, 3, "Comparto con los demás sin vergüenza ni burla, lo que se sobre sexualidad del hombre y de la mujer.", 4 },
                    { 102, 3, "Ma preparo para vivir mi sexualidad unida al amor.", 4 },
                    { 103, 3, "Considero con igual dignidad a hombres y mujeres.", 4 },
                    { 104, 3, "Soy cariñoso con mi familia y acepto las decisiones que se toman en mi casa.", 4 },
                    { 105, 3, "Converso con mis padres sobre lo que consideran bueno para mi y mis hermanos y hermanas.", 4 },
                    { 106, 3, "Estoy siempre dispuesto a ayudar a mis hermanos.", 4 },
                    { 107, 2, "Pienso sobre mi manera de ser y trato cada día de mejorar.", 4 },
                    { 108, 2, "Soy capaz de criticarme.", 4 },
                    { 109, 2, "Se que soy capaz de hacer cosas y de hacerlas bien.", 4 },
                    { 110, 2, "Me esfuerzo cada vez más en superar mis defectos.", 4 },
                    { 111, 2, "Soy constante en mis propósitos.", 4 },
                    { 112, 2, "Cumplo las responsabilidades que asumo.", 4 },
                    { 113, 2, "Comprendo que lo que me piden la Ley y la Promesa Scout es importante para mi vida.", 4 },
                    { 114, 2, "Me esfuerzo por vivir la Ley y la Promesa Scout.", 4 },
                    { 115, 2, "Entiendo que es importante actuar de acuerdo a lo que pienso.", 4 },
                    { 116, 2, "Me esfuerzo por hacer las cosas según lo que pienso.", 4 },
                    { 117, 2, "Contribuyo para que en mi patrulla nos comprometamos con lo que creemos.", 4 },
                    { 118, 2, "Soy alegre.", 4 },
                    { 119, 2, "Ayudo a que en mi Tropa seamos alegres sin ofender a los demás.", 4 },
                    { 120, 2, "Comparto mi alegría con mis amigos y mi familia.", 4 },
                    { 121, 2, "Ayudo a mis compañeros de patrulla a superarse.", 4 },
                    { 122, 2, "Opino y asumo responsabilidades en el Consejo de Patrulla.", 4 },
                    { 123, 1, "Respeto mi cuerpo y el de los demás.", 4 },
                    { 124, 1, "Comprendo que los cambios que se están produciendo en mi cuerpo influyen en mi manera de ser.", 4 },
                    { 125, 1, "Se que hacer frente a una enfermedad o accidente.", 4 },
                    { 126, 1, "Trato de superar las dificultades físicas propias de mi crecimiento.", 4 },
                    { 127, 1, "Converso con mis compañeros para resolver los problemas que se producen entre nosotros.", 4 },
                    { 128, 1, "Me preocupo por mi aspecto personal y siempre trato de estar limpio y ordenado.", 4 },
                    { 129, 1, "Mantengo limpios y ordenados mi dormitorio y mis cosas.", 4 },
                    { 130, 1, "Cuido, limpio y ordeno los lugares en que acampo.", 4 },
                    { 131, 1, "Se que alimentos me ayudan a crecer y cuales no.", 4 },
                    { 132, 1, "Organizo bien mi tiempo para estudiar, compartir con mi familia y estar con mis amigos.", 4 },
                    { 133, 1, "Se preparar comidas sencillas y lo hago con orden y limpieza.", 4 },
                    { 134, 1, "Se elegir entre las diferentes actividades recreativas.", 4 },
                    { 135, 1, "Ayudo a preparar los juegos, excursiones y campamentos de mi patrulla y mi Tropa.", 4 },
                    { 136, 1, "Me esfuerzo por mejorar mi rendimiento en el deporte que practico y sé ganar y perder.", 4 },
                    { 137, 1, "Preparo juegos para distintas ocasiones.", 4 },
                    { 138, 6, "Me preocupo por saber cada vez  más sobre los temas que me interesan.", 4 },
                    { 139, 6, "Saco mis propias conclusiones de los hechos que pasan a mi alrededor.", 4 },
                    { 140, 6, "Me intereso en leer sobre diferentes temas.", 4 },
                    { 141, 6, "Puedo analizar una situación desde distintos puntos de vista.", 4 },
                    { 142, 6, "Propongo temas para discutir en mi patrulla.", 4 },
                    { 143, 6, "Organizo actividades novedosas para realizar con mi patrulla y Tropa.", 4 },
                    { 144, 6, "Coopero en la mantención y renovación del local y materiales de mi patrulla.", 4 },
                    { 145, 6, "Participo en el diseño e instalación de las construcciones de campamento.", 4 },
                    { 146, 6, "Perfecciono mis conocimientos en las especialidades que he elegido.", 4 },
                    { 147, 6, "Aplico mis especialidades en las actividades de servicio.", 4 },
                    { 148, 6, "Expreso por distintos medios mis intereses y aptitudes artísticas.", 4 },
                    { 149, 6, "Ayudo a preparar materiales para las representaciones artísticas.", 4 },
                    { 150, 6, "Me gusta cantar y conozco muchas canciones.", 4 },
                    { 151, 6, "Conozco como funcionan los servicios que uso habitualmente como el teléfono, la electricidad, la radio, la televisión y otros.", 4 },
                    { 152, 6, "He participado en un proyecto que presenta una solución novedosa a un problema técnico habitual.", 4 },
                    { 153, 5, "Preparo y conduzco algunas actividades que nos ayudan a descubrir a Dios en la naturaleza.", 4 },
                    { 154, 5, "Procuro que en mi patrulla nos escuchemos y aprendamos unos de otros.", 4 },
                    { 155, 5, "Leo los libros sagrados de mi fe y converso con adultos que me ayudan a conocerla mejor.", 4 },
                    { 156, 5, "Participo en las celebraciones y actividades de mi religión.", 4 },
                    { 157, 5, "Comparto con mi patrulla reflexiones de los textos sagrados de mi fe.", 4 },
                    { 158, 5, "Entiendo la oración como una manera de conversar con Dios.", 4 },
                    { 159, 5, "Rezo para conversar con Dios y alabarlo, darle gracias, ofrecerle lo que hago y pedirle por las cosas que me pasan.", 4 },
                    { 160, 5, "Me siento feliz cuando los demás ven en mi a una persona que vive de acuerdo a su fe.", 4 },
                    { 161, 5, "Organizo y comparto momentos de oración con mi patrulla y mi familia.", 4 },
                    { 162, 5, "Invito a mi patrulla a cooperar con las acciones que mi comunidad religiosa hace por los demás.", 4 },
                    { 163, 5, "Me interesa conocer otras religiones.", 4 },
                    { 164, 5, "Actúo con respeto frente a las ideas, celebraciones y actividades de otras religiones.", 4 },
                    { 165, 5, "Trato que en mi patrulla se respeten las opciones religiosas de las personas.", 4 },
                    { 166, 4, "Respeto a todas las personas, independientemente de sus ideas, su clase social y su forma de vida.", 4 },
                    { 167, 4, "Ayudo a mi patrulla en los compromisos que tomamos.", 4 },
                    { 168, 4, "Participo en actividades relacionadas con los derechos de las personas.", 4 },
                    { 169, 4, "No me gusta cuando no se respetan los derechos humanos y lo digo.", 4 },
                    { 170, 4, "Sé como se toman las decisiones en mi país y quienes intervienen en ellas.", 4 },
                    { 171, 4, "Considero las opiniones de los demás cuando tengo que tomar decisiones que los afectan.", 4 },
                    { 172, 4, "Opino con respeto sobre las personas que ejercen autoridad.", 4 },
                    { 173, 4, "Respeto las normas de convivencia de los distintos ambientes en que actúo, aunque no siempre esté de acuerdo con ellas.", 4 },
                    { 174, 4, "Opino sobre lo que me gusta o no de las normas de los distintos ambientes en que actúo.", 4 },
                    { 175, 4, "Mantengo una agenda de direcciones útiles.", 4 },
                    { 176, 4, "Realizo una buena acción cada día.", 4 },
                    { 177, 4, "Propongo actividades de servicio de mi patrulla y Tropa y colaboro en su organización.", 4 },
                    { 178, 4, "Me gusta participar en actividades que ayudan a superar las diferencias sociales.", 4 },
                    { 179, 4, "Conozco las diferentes posiciones políticas que hay en mi país.", 4 },
                    { 180, 4, "Conozco la geografía de mi país y su influencia con nuestra cultura.", 4 },
                    { 181, 4, "Aprecio la cultura de mi país y me identifico con ella.", 4 },
                    { 182, 4, "Propongo en mi patrulla y Tropa, actividades que muestren los valores propios de la cultura de nuestro país.", 4 },
                    { 183, 4, "Conozco el Movimiento Scout de mi país.", 4 },
                    { 184, 4, "Participo en los contactos que mantiene mi Grupo con scouts de otros países.", 4 },
                    { 185, 4, "Me gusta saber como viven las personas en otros países.", 4 },
                    { 186, 4, "Se cuales son los principales problemas ambientales de mi país.", 4 },
                    { 187, 4, "Me intereso en conocer en detalle una cultura originaria de América.", 4 },
                    { 188, 4, "Aplico técnicas que me permiten mejorar el medio ambiente y no dañar los lugares en que acampo.", 4 },
                    { 189, 4, "He participadio con mi patrulla  en proyectos de conservación.", 4 },
                    { 190, 3, "Tarto de no esconder mis alegrías, mis penas, las cosas que me gustan y las que me dan miedo.", 1 },
                    { 191, 3, "Acepto separarme de mifamilia cuando voy de campamento con la manada.", 1 },
                    { 192, 3, "Acepto las opiniones de mis compañeros, aunque yo piense distinto.", 1 },
                    { 193, 3, "Trato con cariño a los demás en la Manada y me gusta que me traten igual.", 1 },
                    { 194, 3, "Me gusta tener nuevos amigos y amigas.", 1 },
                    { 195, 3, "Converso y comparto con todas las personas.", 1 },
                    { 196, 3, "Ayudo a los nuevos lobatos y lobeznas para que se sientan contentos en la Manada.", 1 },
                    { 197, 3, "Conozco las diferencias físias entre el hombre y la mujer y nome burlo de eso.", 1 },
                    { 198, 3, "Le pregunto a mis papás cada vez que no sé algo sobre temas sexuales y escucho con atención sus respuestas.", 1 },
                    { 199, 3, "Juego y hago actividades por igual con niños y niñas.", 1 },
                    { 200, 3, "Soy cariñoso con mis papás y demás familiares.", 1 },
                    { 201, 3, "Soy cariñoso con mis hermanos, hago muchas cosas con ellos y trato de no pelear.", 1 },
                    { 202, 2, "Sé lo que puedo hacer.", 1 },
                    { 203, 2, "Reconozco y acepto mis errores.", 1 },
                    { 204, 2, "Paricipo en actividades que me ayudan a descubrir lo que puedo hacer.", 1 },
                    { 205, 2, "Acepto los consejos que me dan mis papás, profesores y dirigentes para ayudarme a ser mejor.", 1 },
                    { 206, 2, "Entiendo  que es bueno que tenga metas que me ayudan a ser cada día mejor.", 1 },
                    { 207, 2, "Conozco La ley y la Promesa de la Manada y entiendo lo que significa.", 1 },
                    { 208, 2, "He prometido cumplir la Ley y la Promesa de la Manada.", 1 },
                    { 209, 2, "Se lo que significa decir la verdad.", 1 },
                    { 210, 2, "He aprendido que en las cosas que hago con mis compañeros y amigos debo cumplir la Ley de la Manada.", 1 },
                    { 211, 2, "Paricipo en juegos y representaciones que muestran la importancia de decir la verdad.", 1 },
                    { 212, 2, "Casi siempre estoy alegre.", 1 },
                    { 213, 2, "Paricipo con alegría en las actividades de la Manada.", 1 },
                    { 214, 2, "Tengo buen humor y puedo hacer bromas sin burlarme de los demás.", 1 },
                    { 215, 2, "Escucho a los demás lobatos y lobeznas, a mis papás y a mis dirigentes.", 1 },
                    { 216, 1, "Trato de seguir los consejos que me dan los más grandes para tener un cuerpo fuerte y sano.", 1 },
                    { 217, 1, "Se en que lugar de mi cuerpo están ubicados los organos más importantes.", 1 },
                    { 218, 1, "Conozco las principales enfermedades que me pueden dar y por qué.", 1 },
                    { 219, 1, "Participo en actividades que me ayudan a tener un cuerpo cada vez más fuerte, agil, veloz y flexible.", 1 },
                    { 220, 1, "Cuando algo me molesta lo digo sin necesidad de pelear con los demás.", 1 },
                    { 221, 1, "Me preocupo porque mi cuerpo esté limpio.", 1 },
                    { 222, 1, "Ayudo a limpiar y ordenar los lugares en que estoy.", 1 },
                    { 223, 1, "Trato de comer de todo y no digo que algo no me gustas sin haberlo probado antes.", 1 },
                    { 224, 1, "Como a las horas adecuada y no a cada rato.", 1 },
                    { 225, 1, "Hago a tiempo y con calma las tareas que me dan en la escuela.", 1 },
                    { 226, 1, "Me gusta hacer actividades al aire libre.", 1 },
                    { 227, 1, "Me gusta jugar con compañeros de mi edad.", 1 },
                    { 228, 1, "Me gusta practicar deportes.", 1 },
                    { 229, 6, "Converso con los demás sobre las cosas que me llaman la atención.", 1 },
                    { 230, 6, "Participo en actividades donde puedo conocer algo nuevo.", 1 },
                    { 231, 6, "Leo las historias que me recomiendan mis papás, mis profesores y mis dirigentes.", 1 },
                    { 232, 6, "No me olvido de las cosas que me pasan.", 1 },
                    { 233, 6, "Puedo contar con detalles las anécdotas y aventuras que hemos tenido en la manada.", 1 },
                    { 234, 6, "Me gusta participar en juegos de observación.", 1 },
                    { 235, 6, "Participo en los talleres de manualidades que se hacen en la manada.", 1 },
                    { 236, 6, "Sé para que sirven las herramientas que uso.", 1 },
                    { 237, 6, "Sé lo que hacen las personas en los trabajos más conocidos.", 1 },
                    { 238, 6, "Participo en actividades que me ayudan a conocer más sobre los diferentes trabajos de las personas.", 1 },
                    { 239, 6, "Quiero conocer y manejar nuevos objetos.", 1 },
                    { 240, 6, "Se cómo se usan y para qué sirven los objetos que conozco; y puedo explicárselo a los demás.", 1 },
                    { 241, 5, "Me gusta mucho la naturaleza y la vida al aire lire.", 1 },
                    { 242, 5, "Reconozco las buenas acciones que hacen mis compañeros y compañeras.", 1 },
                    { 243, 5, "Tengo interés en conocer cada vez más sobre Dios y mi religión.", 1 },
                    { 244, 5, "Participo con mi familia en las celebraciones de mi religión.", 1 },
                    { 245, 5, "Participo en las celebraciones religiosas que se hacen en mi Manada.", 1 },
                    { 246, 5, "Participo en las oraciones que hacemos en la Manada.", 1 },
                    { 247, 5, "Conozco las principales oraciones de la Manada.", 1 },
                    { 248, 5, "Participo con mi familia cuando decimos juntos una oración.", 1 },
                    { 249, 5, "Conozco la historia de algunas personas que han vivido de acuerdo a su fé.", 1 },
                    { 250, 5, "Entiendo que las cosas que aprendo de mi religión se tienen que notar en la forma en que soy con mi familia.", 1 },
                    { 251, 4, "Comparto lo que tengo con mis compañeros y compañeras.", 1 },
                    { 252, 4, "Cumplo las tareas de servicio que se me encarga en la Manada.", 1 },
                    { 253, 4, "Participo en juesgos y actividades sobre los derechos del niño.", 1 },
                    { 254, 4, "Se por qué tengo que respetar las decisiones que toman los mayores.", 1 },
                    { 255, 4, "Ayudo a mis compañeros cuando les toca dirigir alguna actividad en la escuela y la Manada.", 1 },
                    { 256, 4, "Acepto las reglas que se ponen en mi casa, en la escuela y en la Manada.", 1 },
                    { 257, 4, "Se donde están los bomberos,  la policia, el hospital y algunos servicios públicos del lugar donde vivo.", 1 },
                    { 258, 4, "Ayudo en mi casa tan pronto como me lo piden.", 1 },
                    { 259, 4, "Conozco los símbolos de mi país, como por ejemplo la bandera, el himno y el escudo.", 1 },
                    { 260, 4, "Respeto los símbolos de mi país.", 1 },
                    { 261, 4, "Participo con respeto y entusiasmo en las celebraciones patrias.", 1 },
                    { 262, 4, "Se cuáles son las distintas Unidades que hay en mi Grupo y conozco sus nombres.", 1 },
                    { 263, 4, "Participo en actividades con otras unidades de mi Grupo.", 1 },
                    { 264, 4, "Sé cuáles son los países americanos.", 1 },
                    { 265, 4, "Conozco los principales árboles, plantas, animales, peces y aves de la región en que vivo.", 1 },
                    { 266, 4, "Cuido las pantas que hay en mi casa.", 1 },
                    { 267, 4, "He sembrado y cuidado una o varias plantas.", 1 },
                    { 268, 3, "Puedo hablar con los demás de las cosas que me ponen alegre y tambien de las que me ponen triste.", 2 },
                    { 269, 3, "Acepto cuando en la Manada me dicen que no hice algo bien, aunque no siempre este de acuerdo.", 2 },
                    { 270, 3, "Pienso bien lo que voy a hacer antes de hacerlo.", 2 },
                    { 271, 3, "Digo lo que pienso sin ofender o insultar a mis compañeros ni burlarme de ellos.", 2 },
                    { 272, 3, "Soy cada vez mas amigo de mis amigos y amigas, pero igual aprecio a mis demás compañeros.", 2 },
                    { 273, 3, "Estoy siempre dispuesto a ayudar a los demás.", 2 },
                    { 274, 3, "Comparto con todos mis compañeros, sin importar su raza, en que trabajan sus papás, o si tienen o no dinero.", 2 },
                    { 275, 3, "Se cómo una mujer queda embarazada, como nacen los bebés y que hacen el hombre y la mujer en esos procesos naturales.", 2 },
                    { 276, 3, "Trato con igual justicia y de las misma manera a mis compañeras y a mis compañeros.", 2 },
                    { 277, 3, "Le cuento a mi familia las cosas que hacemos en la Manada.", 2 },
                    { 278, 3, "Comparto con la familia de mis amigos y amigas y los invito a que compartan con mi familia.", 2 },
                    { 279, 2, "Sé lo que puedo hacer y lo que no puedo hacer.", 2 },
                    { 280, 2, "Acepto mis defectos y sé que existen cosas que aún no puedo hacer.", 2 },
                    { 281, 2, "Le doy importancia a las cosas que hago.", 2 },
                    { 282, 2, "Me propongo tareas y metas que me ayudan a superar mis defectos.", 2 },
                    { 283, 2, "Hago bien los trabajos que acepto.", 2 },
                    { 284, 2, "Sé lo que significa cumplir la Ley y la Promesa en mi vida diaria.", 2 },
                    { 285, 2, "Trato de cumplir la Ley y la Promesa en la Manada, en mi casa y en mi escuela.", 2 },
                    { 286, 2, "Digo la verdad, aunque a veces no me gusten las consecuencias.", 2 },
                    { 287, 2, "Entiendo que tengo que cumplir la Ley de la Manada también en mi casa.", 2 },
                    { 288, 2, "Ayudo a que en la Manada se diga siempre la verdad.", 2 },
                    { 289, 2, "Enfrento las dificultades con buen ánimo.", 2 },
                    { 290, 2, "Me siento feliz cuando logro lo que me propuse; y tambien cuando a mis compañeros la cosas les resultan bien.", 2 },
                    { 291, 2, "Ayudo a que en la Manada nos riamos sin ofender a los demás.", 2 },
                    { 292, 2, "Me llevo bien con todos los lobatos y las lobeznas de la Manada.", 2 },
                    { 293, 2, "Tengo amigos y amigas con los que siempre juego y me encuentro.", 2 },
                    { 294, 1, "He aprendido a medir los riesgos que tienen los juegos y las cosa que hago.", 2 },
                    { 295, 1, "Entiendo para que sirven los sistemas más importantes de mi cuerpo.", 2 },
                    { 296, 1, "Tengo hábitos que protegen mi salud, como por ejemplo, lavarme las manos despues de ir al baño.", 2 },
                    { 297, 1, "Manejo cada vez mejor mis brazos, piernas, manos y pies.", 2 },
                    { 298, 1, "Arreglo mis problemas con mis compañeros sin usar la fuerza.", 2 },
                    { 299, 1, "Ando siempre limpio y se nota, por ejemplo , en mi pelo, orejas, dientes y uñas.", 2 },
                    { 300, 1, "Mantego ordenada y limpia mi habitación y los lugares en que trabajo y juego.", 2 },
                    { 301, 1, "Se que tengo que comer los alimentos que me ayudan a crecer.", 2 },
                    { 302, 1, "Cuando como o preparo alimentos me preocupo de lavarme y de que todo este limpio.", 2 },
                    { 303, 1, "Se distribuir mi tiempo entre las distintas cosas que hago.", 2 },
                    { 304, 1, "Duermo las horas que necesito para descansar bien.", 2 },
                    { 305, 1, "Ayudo a preparar las excursiones de la Manada.", 2 },
                    { 306, 1, "Practico deportes, conozco sus reglas y sé perder.", 2 },
                    { 307, 1, "Me gusta jugar con otros niños y niñas y respeto las reglas de juego.", 2 },
                    { 308, 6, "Quiero aprender cosa nuevas.", 2 },
                    { 309, 6, "Investigo y descubro como funcionan las cosas.", 2 },
                    { 310, 6, "Soy capaz de contarle a los demás lo que leo y aprendo.", 2 },
                    { 311, 6, "Relaciono las cosas imaginarias con las que pasan de verdad.", 2 },
                    { 312, 6, "Saco mis propias conclusiones de los cuentos e historias que leo.", 2 },
                    { 313, 6, "Me gustan los juegos en que tengo que usar mi agilidad mental.", 2 },
                    { 314, 6, "Practico continuamente mis ahabilidades manuales.", 2 },
                    { 315, 6, "Hago trabajos cada vez mejores con mis manos.", 2 },
                    { 316, 6, "Demuestro las distintas cosas que puedo hacer.", 2 },
                    { 317, 6, "Participo en representaciones artisticas sobre las profesiones y oficios.", 2 },
                    { 318, 6, "En las actividades que hago se nota lo que pienso y siento.", 2 },
                    { 319, 6, "Trato de hablar claro y conocer nuevas palabras.", 2 },
                    { 320, 6, "Me doy cuenta y me gusta cuando los demás hablan bien.", 2 },
                    { 321, 6, "Quiero saber por qué ocurren las cosas.", 2 },
                    { 322, 6, "Le busco solución a los problemas que aparecen en las cosas que hago.", 2 },
                    { 323, 5, "He aprendido a reconocer la naturaleza como obra de Dios.", 2 },
                    { 324, 5, "Me gusta cuando las personas hacen cosas buenas  por los demás.", 2 },
                    { 325, 5, "Pregunto a las demás personas sobre las cosas que me interesan de mi religión.", 2 },
                    { 326, 5, "Participo en actividades en que aprendo sobre mi religión.", 2 },
                    { 327, 5, "Ayudo a las celebraciones religiosas de la Manada.", 2 },
                    { 328, 5, "Comprendo la importancia de rezar juntos en la Manada.", 2 },
                    { 329, 5, "Rezo en los momentos importantes del día.", 2 },
                    { 330, 5, "A veces yo dirijo las oraciones que decimos en la Manada.", 2 },
                    { 331, 5, "Me doy cuenta cuando las personas viven de acuerdo a las enseñanzas de su religión.", 2 },
                    { 332, 5, "Comprendo que las enseñanzas de mi religión se tienen que notar en la forma en que soy con mis amigos y compañeros.", 2 },
                    { 333, 5, "Todos mis compañeros son importantes, aunque no tengan mi misma religión.", 2 },
                    { 334, 5, "Conozco que hay otras religiones distintas de la mía.", 2 },
                    { 335, 4, "Respeto las opiniones de los demás.", 2 },
                    { 336, 4, "Ayudo siempre en las tareas de servicio que se deben hacer en la Manada.", 2 },
                    { 337, 4, "Conozco los derechos del niño y los relaciono con situaciones que conozco o con otras de las que he oido hablar.", 2 },
                    { 338, 4, "Respeto a mis papás y profesores y las decisiones que toman.", 2 },
                    { 339, 4, "Elijo con mis compañeros a los seiseneros y a los que dirigen las actividades en que participo, y siempre ayudo al que ganó.", 2 },
                    { 340, 4, "Comprendo y respeto las normas que se han puesto en mi casa y en la escuela, aunque no siempre está de acuerdo con ellas.", 2 },
                    { 341, 4, "Digo con respeto lo que me gusta y lo que no me gusta de las normas que hay en mi casa y en la escuela.", 2 },
                    { 342, 4, "Se cuales son y dónde están los principales servicios públicos del lugar donde vivo.", 2 },
                    { 343, 4, "Ayudo siempre en las tareas que hay que hacer en mi casa y en la escuela.", 2 },
                    { 344, 4, "Participo siempre en campañas de ayuda a quienes lo necesitan.", 2 },
                    { 345, 4, "Algo conozco de las cosas típicas del lugar en que vivo.", 2 },
                    { 346, 4, "Me gusta la cultura de mi país y las distintas formas en que se expresa.", 2 },
                    { 347, 4, "Participo en las actividades de la Manada en que se expresa la cultura de mi país.", 2 },
                    { 348, 4, "Puedo nombrar la mayoría de los Grupos Scouts que quedan cerca del mío.", 2 },
                    { 349, 4, "Participo en actividades de intercambio con Manadas de otros Grupos.", 2 },
                    { 350, 4, "Conozco los símbolos patrios de otros países de América.", 2 },
                    { 351, 4, "Participo en actividades en que aprendo lo importante que es la paz.", 2 },
                    { 352, 4, "Conozco los principales animales y plantas de mi país que podrian desaparecer si no hacemos algo por ellos.", 2 },
                    { 353, 4, "Cuido los árboles y las plantas en los lugares en que juego, trabajo y vivo.", 2 },
                    { 354, 3, "Logro progresivamente manejar mis emociones y sentimientos, dando estabilidad a mi estado de Ánimo.", 5 },
                    { 355, 3, "Comparto y defiendo el derecho de los demás a ser valorados por lo que son y no por lo que tienen.", 5 },
                    { 356, 3, "Tengo opiniones y actitudes coincidentes con mis valores frente a temas relacionados con la sexualidad tales como el aborto, la homosexualidad, las relaciones sexuales prematrimoniales y otros.", 5 },
                    { 357, 3, "Mis relaciones afectivas con el sexo complementario son un testimonio de amor y responsabilidad.", 5 },
                    { 358, 3, "Asumo ante el sexo complementario una actitud de respeto e igualdad.", 5 },
                    { 359, 3, "Participo en actividades destinadas a obtener la igualdad de derecho y oportunidades entre el hombre y la mujer.", 5 },
                    { 360, 3, "Logro una relación de comprensión y afecto con mis padres, manteniendo una permanente comunicación con ellos.", 5 },
                    { 361, 3, "Logro que mis padres consideren mis discrepancias, confíen en mi y amplíen mi autonomía personal, respetando a la vez los limites convenidos.", 5 },
                    { 362, 3, "Mantengo un diálogo enriquecedor con mis hermanos.", 5 },
                    { 363, 3, "Asumo mi relación de pareja dentro de mi proyecto de vida, en la perspectiva de una preparación a la futura vida en común.", 5 },
                    { 364, 3, "Me preocupo por encontrar mi identidad como persona.", 5 },
                    { 365, 3, "Acepto sin deprimirme la frustración que me producen mis fracasos.", 5 },
                    { 366, 3, "Comparto mis sentimientos con mi equipo.", 5 },
                    { 367, 3, "Puedo expresar libremente mis opiniones, en distintas circunstancias, sin descalificar a los demás.", 5 },
                    { 368, 3, "Soy naturalmente afectuoso con las personas.", 5 },
                    { 369, 3, "Mantengo amistades profundas.", 5 },
                    { 370, 3, "Identifico el amor hacia los demás como fuente de mi realización y de mi felicidad.", 5 },
                    { 371, 3, "Demuestro capacidad de entregar sin esperar retribución.", 5 },
                    { 372, 2, "Evalúo mis resultados.", 5 },
                    { 373, 2, "Soy capaz de proyectar para mi vida adulta las posibilidades de mis actuales capacidades y limitaciones.", 5 },
                    { 374, 2, "Soy fiel a la palabra dada.", 5 },
                    { 375, 2, "Soy testimonio de los valores que me inspiran todos los ámbitos en que actúo.", 5 },
                    { 376, 2, "Contribuyo a que mi unidad se cifre el honor común en ser consecuentes.", 5 },
                    { 377, 2, "Soy capaz de reírme de mis propios absurdos.", 5 },
                    { 378, 2, "Soy reconocido por mi actitud de alegría y optimismo. En todo los ambientes en que participo.", 5 },
                    { 379, 2, "Practico un humor exento de hostilidad y vulgaridad.", 5 },
                    { 380, 2, "Reconozco en mi equipo una comunidad de vida y acepto las críticas que se formulan..", 5 },
                    { 381, 2, "Aporto mi experiencia personal en las reuniones de mi equipo.", 5 },
                    { 382, 2, "Me comprometo en los proyectos de mi unidad y de mi grupo.", 5 },
                    { 383, 2, "Demuestro que acepto, no obstante mi capacidad de mirarme críticamente.", 5 },
                    { 384, 2, "Confío en que soy capaz de lograr mis propósitos.", 5 },
                    { 385, 2, "Formulo metas para mi crecimiento personal.", 5 },
                    { 386, 2, "Realizo acciones y participo en proyectos destinados a cumplir mis metas.", 5 },
                    { 387, 2, "Reconozco el significado de la Ley y los Principios en esta etapa de mi desarrollo.", 5 },
                    { 388, 2, "Renuevo mi compromiso con el Movimiento Scout.", 5 },
                    { 389, 2, "Opto por valores personales para mi vida.", 5 },
                    { 390, 1, "Preparo programas de alimentación apropiadas para las actividades de mi unidad.", 5 },
                    { 391, 1, "Valoro el tiempo y lo distribuyo adecuadamente entre obligaciones, vida familiar y actividades de integración social.", 5 },
                    { 392, 1, "Incorporo permanentemente a mi descanso actividades recreativas variadas.", 5 },
                    { 393, 1, "Acampo regularmente en buenas condiciones técnicas.", 5 },
                    { 394, 1, "Integro en mis actividades habituales la práctica sistemática de un deporte.", 5 },
                    { 395, 1, "Participo en la organización de juegos y actividades para los demás.", 5 },
                    { 396, 1, "Acepto mi imagen corporal.", 5 },
                    { 397, 1, "Me esfuerzo por privilegiar comportamientos reflexivos por sobre reacciones violentas.", 5 },
                    { 398, 1, "Mantengo constantemente un aspecto personal de orden e higiene.", 5 },
                    { 399, 1, "Asumo tareas permanentes en la mantención del orden y limpieza de mi hogar.", 5 },
                    { 400, 1, "Mantengo una alimentación completa de acuerdo a mi edad.", 5 },
                    { 401, 1, "Respeto las diferentes comidas del día y horarios.", 5 },
                    { 402, 1, "Comprendo las diferencias físicas y psicológicas en el desarrollo del hombre y de la mujer.", 5 },
                    { 403, 1, "Demuestro constancia en el cuidado de mi salud y evito hábitos que la deterioran.", 5 },
                    { 404, 1, "Mantengo un buen estado físico.", 5 },
                    { 405, 6, "Concentro progresivamente mi autoformación en materias vinculadas a mis opciones vocacionales.", 5 },
                    { 406, 6, "Defino mis alternativas vocacionales considerando las distintas variables que la determinan.", 5 },
                    { 407, 6, "Comparto mis inquietudes, aspiraciones y creaciones artísticas.", 5 },
                    { 408, 6, "Demuestro selectividad en mis afinidades artísticas y culturales.", 5 },
                    { 409, 6, "Tiendo a expresarme de un modo propio, apreciando críticamente tendencias e ídolos sociales.", 5 },
                    { 410, 6, "Relaciono mis valores con los métodos que utiliza la ciencia.", 5 },
                    { 411, 6, "Participo en la aplicación de un proyecto que utilice tecnología innovadora.", 5 },
                    { 412, 6, "Me informo habitualmente de la actualidad por distintos medios y demuestro capacidad de valorar críticamente lo que veo, leo y escucho.", 5 },
                    { 413, 6, "Fundamento mis apreciaciones sobre los artículos de opinión que leo frecuentemente.", 5 },
                    { 414, 6, "Demuestro capacidad de sintetizar, criticar y proponer.", 5 },
                    { 415, 6, "Presento continuamente asuntos para ser reflexionados y realizados en equipo.", 5 },
                    { 416, 6, "Creo juegos y dinámicas de grupo para ser utilizados por mi equipo y desarrollo acciones motivarlas..", 5 },
                    { 417, 6, "Puedo resolver la mayoría de los problemas técnicos domésticos.", 5 },
                    { 418, 6, "Amplio mis habilidades hacia campos técnicos más complejos: sonido, imagen, mecánica, informática, otros.", 5 },
                    { 419, 6, "Desarrollo algunas especialidades propias de la rama.", 5 },
                    { 420, 5, "Demuestro a través de mi actitud hacia la naturaleza que tomo conciencia de mi responsabilidad como colaborador de la obra.", 5 },
                    { 421, 5, "Reviso constantemente la consecuencia existente entre mis creencias y mis actos.", 5 },
                    { 422, 5, "Comparto con otros jóvenes mi experiencia de fidelidad con los valores de mi fe.", 5 },
                    { 423, 5, "Promuevo en mi unidad la realización de acciones propias de la dimensión social de la fe de sus integrantes.", 5 },
                    { 424, 5, "Me intereso por conocer el pensamiento religioso diferente de las personas con quienes comparto.", 5 },
                    { 425, 5, "Conozco los conceptos básicos de las principales religiones.", 5 },
                    { 426, 5, "Participo en actividades destinadas a dialogar con jóvenes de diferentes ideas religiosas.", 5 },
                    { 427, 5, "Desarrollo una actitud crítica frente a las manifestaciones espirituales contrarias a los valores del Movimiento Scout.", 5 },
                    { 428, 5, "Organizo actividades destinadas a dar a conocer el testimonio de otras personas.", 5 },
                    { 429, 5, "Profundizo mi formación en la religión que profeso.", 5 },
                    { 430, 5, "Confirmo mi opción de fe en la forma establecida por mi iglesia.", 5 },
                    { 431, 5, "Colaboro en las acciones emprendidas por mi comunidad.", 5 },
                    { 432, 5, "Colaboro en las acciones de educación de la fe de los compañeros de mi unidad participes de mi opción religiosa.", 5 },
                    { 433, 5, "Me preocupo por mantener diariamente momentos de silencio reflexión y oración personal.", 5 },
                    { 434, 5, "Integro la oración en las decisiones más importantes de mi vida.", 5 },
                    { 435, 5, "Preparo oraciones para distintos momentos de la vida de mi unidad, de mi grupo y de mi familia.", 5 },
                    { 436, 4, "Demuestro que reconozco como iguales en dignidad a las personas diferentes a mí.", 5 },
                    { 437, 4, "Demuestro esfuerzos por orientar creativamente las tendencias a la rebeldía y a la oposición.", 5 },
                    { 438, 4, "Conozco las principales organizaciones sociales y de servicio de mi comunidad local.", 5 },
                    { 439, 4, "Participo en las actividades de servicio que se desarrollan en mi colegio o trabajo.", 5 },
                    { 440, 4, "Participo activamente en campañas de desarrollo de la comunidad organizadas por mi Grupo, Distrito o por la Asociación.", 5 },
                    { 441, 4, "Demuestro por distintos medios mi compromiso con la superación de las diferencias sociales.", 5 },
                    { 442, 4, "Valoro críticamente las ideologías y posiciones políticas de mi país.", 5 },
                    { 443, 4, "Conozco la herencia artística de mi cultura: historias, leyendas, danzas, canciones, mitos, artesanías, etc.", 5 },
                    { 444, 4, "Soy capaz de apreciar críticamente los elementos, cambios y metas de mi cultura.", 5 },
                    { 445, 4, "Expreso a través de alguna de mis habilidades artísticas mi afecto por los valores de mi cultura.", 5 },
                    { 446, 4, "Conozco la información general sobre el Movimiento Scout en América.", 5 },
                    { 447, 4, "Estoy siempre disponible para las tareas pesadas.", 5 },
                    { 448, 4, "Participo o he participado en eventos nacionales o internacionales con la asistencia de scouts de otros países.", 5 },
                    { 449, 4, "Participo en actividades o proyectos destinados a la comprensión interamericana.", 5 },
                    { 450, 4, "Demuestro que valoro la diversidad cultural.", 5 },
                    { 451, 4, "Fundamento mis opiniones sobre los problemas urgentes que afectan al medio ambiente de mi comunidad local.", 5 },
                    { 452, 4, "Aplico en mis campamentos, o en mis proyectos específicos, algunas tecnologías que preservan o mejoran el medio ambiente.", 5 },
                    { 453, 4, "Desarrollo proyectos de conservación en que intervienen otros jóvenes no scouts.", 5 },
                    { 454, 4, "Asumo una posición activa frente a los atropellos a las personas que observo en mi vida cotidiana.", 5 },
                    { 455, 4, "Demuestro que valoro la democracia como sistema de generación de la autoridad.", 5 },
                    { 456, 4, "Respeto la autoridad válidamente elegida aunque no comparta sus ideas.", 5 },
                    { 457, 4, "Acepto las decisiones de mis padres y expreso con respeto mis distintos puntos de vista.", 5 },
                    { 458, 4, "Ejerzo mi autoridad sin autoritarismo ni abuso.", 5 },
                    { 459, 4, "Comprendo la importancia de la norma para el desarrollo de mi libertad con respeto a la libertad de otros.", 5 },
                    { 460, 4, "Acepto las normas sin renunciar a mi derecho por su cambio.", 5 },
                    { 461, 3, "Logra y mantiene un estado interior de libertad, equilibrio y madurez emocional.", 6 },
                    { 462, 3, "Practica una conducta asertiva y una actitud afectuosa hacia las demás personas, sin inhibiciones ni agresividad.", 6 },
                    { 463, 3, "Construye su felicidad personal en el amor, sirviendo a los otros sin esperar recompensa y valorándolos por lo que son.", 6 },
                    { 464, 3, "Conoce, acepta y respeta su sexualidad y la del sexo complementario como expresión del amor.", 6 },
                    { 465, 3, "Reconoce el matrimonio y la familia como base de la sociedad, convirtiendo la suya en una comunidad de amor conyugal, filial y fraterno.", 6 },
                    { 466, 2, "Conoce sus posibilidades y limitaciones, aceptándose con capacidad de autocrítica y manteniendo a la vez una buena imagen de sí mismo.", 6 },
                    { 467, 2, "Es el principal responsable de su desarrollo y se esfuerza por superarse constantemente.", 6 },
                    { 468, 2, "Construye su proyecto de vida en base a los valores de la Ley y la Promesa Scout.", 6 },
                    { 469, 2, "Actúa consecuentemente con los valores que lo inspiran.", 6 },
                    { 470, 2, "Enfrenta la vida con alegría y sentido del humor.", 6 },
                    { 471, 2, "Reconoce en su grupo de pertenencia un apoyo para su crecimiento personal y para la realización de su proyecto de vida.", 6 },
                    { 472, 1, "Asume la parte de responsabilidad que le corresponde en el desarrollo armónico de su cuerpo.", 6 },
                    { 473, 1, "Conoce los procesos biológicos que regulan su organismo, protege su salud, acepta sus posibilidades físicas y orienta sus impulsos y fuerzas.", 6 },
                    { 474, 1, "Valora su aspecto y cuida su higiene personal y la de su entorno.", 6 },
                    { 475, 1, "Mantiene una alimentación sencilla y adecuada.", 6 },
                    { 476, 1, "Administra su tiempo equilibradamente entre sus diversas obligaciones, practicando formas apropiadas de descanso.", 6 },
                    { 477, 1, "Convive constantemente en la naturaleza y participa en actividades deportivas y recreativas.", 6 },
                    { 478, 6, "Incrementa continuamente sus conocimientos mediante la autoformación y el aprendizaje sistemático.", 6 },
                    { 479, 6, "Actúa con agilidad mental ante las situaciones más diversas, desarrollando su capacidad de pensar, innovar y aventurar.", 6 },
                    { 480, 6, "Une los conocimientos teórico y práctico mediante la aplicación constante de sus habilidades técnicas y manuales", 6 },
                    { 481, 6, "Elige su vocación considerando conjuntamente sus aptitudes, posibilidades e intereses; y valora sin prejuicios las opciones de los demás.", 6 },
                    { 482, 6, "Expresa lo que piensa y siente a través de distintos medios, creando en los ambientes en que actúa espacios gratos que faciliten el encuentro y el perfeccionamiento entre las personas.", 6 },
                    { 483, 6, "Valora la ciencia y la técnica como medios para comprender y servir al hombre, la sociedad y el mundo.", 6 },
                    { 484, 5, "Busca siempre a Dios en forma personal y comunitaria, aprendiendo a reconocerlo en los hombres y en la Creación.", 6 },
                    { 485, 5, "Adhiere a principios espirituales, es fiel a la religión que los expresa y acepta los deberes que de ello se desprenden.", 6 },
                    { 486, 5, "Practica la oración personal y comunitaria, como expresión del amor a Dios y como un medio de relacionarse con Él.", 6 },
                    { 487, 5, "Integra sus principios religiosos a su conducta cotidiana, estableciendo coherencia entre su fe, su vida personal y su participación social.", 6 },
                    { 488, 5, "Dialoga con todas las personas cualquiera sea su opción religiosa, buscando establecer vínculos de comunión entre los hombres.", 6 },
                    { 489, 4, "Vive su libertad de un modo solidario, ejerciendo sus derechos, cumpliendo sus obligaciones y defendiendo igual derecho para los demás.", 6 },
                    { 490, 4, "Reconoce y respeta la autoridad válidamente establecida y la ejerce al servicio de los demás.", 6 },
                    { 491, 4, "Cumple las normas que la sociedad se ha dado, evaluándolas con responsabilidad y sin renunciar a cambiarlas.", 6 },
                    { 492, 4, "Sirve activamente en su comunidad local, contribuyendo a crear una sociedad justa, participativa y fraterna.", 6 },
                    { 493, 4, "Hace suyos los valores de su país, su pueblo y su cultura.", 6 },
                    { 494, 4, "Promueve la cooperación internacional, la hermandad mundial y el encuentro de los pueblos, luchando por la comprensión y la paz.", 6 },
                    { 495, 4, "Contribuye a preservar la vida a través de la conservación de la integridad del mundo natural.", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "ObjetivosEducativos",
                keyColumn: "Id",
                keyValue: 495);
        }
    }
}
