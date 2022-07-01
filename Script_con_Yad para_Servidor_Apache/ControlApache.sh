yad --title="Control Apache" \
    --center \
    --width=250 \
    --height=80 \
    --text-align=center \
    --text="¿Que quiere hacer?" \
    --button=Arrancar:0 \
    --button=Detener:1 \
    --button=Reiniciar:2  \
    --button=Estado:3 
ans=$?
if [ $ans -eq 0 ]
then
    systemctl start httpd
    echo "El servidor se ha iniciado"
fi
if [ $ans -eq 1 ]
then
    systemctl stop httpd
    echo "El servidor se ha detenido"
fi
if [ $ans -eq 2 ]
then
   systemctl restart httpd
   echo "El servidor se ha reiniciado"
fi
if [ $ans -eq 3 ]
then
   echo ""
   echo ""
   systemctl status httpd    
fi
exit
