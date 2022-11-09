using System.Drawing.Imaging;

namespace SRD_BackOffice
{
    public partial class MenuCrearEvento : Form
    {
        bool modify, startModify = false, avoid = false;
        string eqName, encName;
        Bitmap imagenCargada = null;
        int index, cantFases = 1, faseSeleccionada = 1, groupAmount = 1, groupSize = 2, eqId, lblId = 0, txtId = 0, txtPos = 0, tipoFase = 1, encId;
        List<Fase> fases = new List<Fase>();
        List<EquiposFases> equiposFases = new List<EquiposFases>();
        List<EncuentrosFases> encuentrosFases = new List<EncuentrosFases>();
        List<Control> controls = new List<Control>();

        public MenuCrearEvento()
        {
            InitializeComponent();
            SetIdioma();

            SetControls();

            fases.Add(new Fase());

            btnLinkedMatchs.Click += (sender, EventArgs) => { btnListEncuentros_Click(sender, EventArgs); };
            btnLinkMatch.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, 0, txtId, txtPos, true); };

            cbxTipoFase.SelectedIndex = 1;
            cbxFase.SelectedIndex = 0;
            btnLinkedMatchs.Hide();
            btnLinkMatch.Hide();
            panelFases.Hide();
            panelBuscadorEquipos.Hide();
            panelEncuentros.Hide();
        }

        public MenuCrearEvento(int index)
        {
            InitializeComponent();
            SetIdioma();

            this.index = index;
            modify = true;
            avoid = true;
            startModify = true;
            btnAddEvent.Text = "Modify";
            txtFechaEvento.ForeColor = Color.Black;
            txtFechaFase.ForeColor = Color.Black;
            txtHoraEvento.ForeColor = Color.Black;

            SetControls();

            var evento = Logica.GetEventos(4, "" + index)[0];

            txtNombreEvento.Text = evento.NombreEvento;
            try
            {
                txtHoraEvento.Text = evento.HoraEvento.Substring(0, evento.HoraEvento.Length - 3);
            } catch { }
            try
            {
                txtFechaEvento.Text = evento.FechaEvento.Substring(0, evento.FechaEvento.Length - 8);
            } catch { }
            txtlugarEvento.Text = evento.Lugar;
            cbxEstadoEvento.Text = evento.EstadoEvento;
            string path = evento.LogoEvento;
            try
            {
                imagenCargada = new Bitmap(path);
            } catch { }
            imgEventSelected.Image = imagenCargada;

            evento.Fases = Logica.GetFases(2, ""+index);

            btnLinkedMatchs.Click += (sender, EventArgs) => { btnListEncuentros_Click(sender, EventArgs); };
            btnLinkMatch.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, 0, txtId, txtPos, true); };

            cantFases = evento.Fases.Count();
            txtCantFases.Text = "" + cantFases;
            int c = 1;
            foreach (var f in evento.Fases)
            {
                f.EquiposParticipantes = Logica.GetEquiposFases(1, "" + index, ""+c);
                if (f.EquiposParticipantes == null) { f.EquiposParticipantes = new List<EquiposFases>(); }
                f.EncuentrosParticipantes = Logica.GetEncuentrosFases(1, "" + index, ""+c);
                if (f.EncuentrosParticipantes == null) { f.EncuentrosParticipantes = new List<EncuentrosFases>(); }
                fases.Add(f);
                if (c > 1)
                {
                    cbxFase.Items.Add(c);
                }
                c++;
            }

            Fase fase = fases[0];

            try
            {
                txtFechaFase.Text = fase.FechaFase.Substring(0, fase.FechaFase.Length - 8);
            } catch { }
            txtNombreFase.Text = fase.NombreFase;
            cbxEstadoFase.Text = fase.EstadoFase;
            groupSize = fase.TamañoGrupos;
            groupAmount = fase.CantidadGrupos;

            equiposFases = fase.EquiposParticipantes;
            encuentrosFases = fase.EncuentrosParticipantes;

            cbxFase.SelectedIndex = 0;
            cbxTipoFase.SelectedIndex = fase.TipoFase - 1;
            panelFases.Hide();
            panelBuscadorEquipos.Hide();
            panelEncuentros.Hide();
        }

        private void cbxFase_SelectedIndexChanged(object sender, EventArgs e) //Cambia la fase
        {

            if (startModify == false)
            {
                //Guarda los datos de la fase anterior
                Fase fase = new Fase();

                fase.NumeroFase = faseSeleccionada;
                fase.FechaFase = txtFechaFase.Text;
                fase.NombreFase = txtNombreFase.Text;
                fase.TipoFase = Convert.ToInt32(cbxTipoFase.Text);
                fase.EquiposParticipantes = equiposFases;
                fase.EncuentrosParticipantes = encuentrosFases;
                fase.TamañoGrupos = groupSize;
                fase.CantidadGrupos = groupAmount;
                fase.EstadoFase = cbxEstadoFase.Text;

                fases.RemoveAt(faseSeleccionada - 1);
                fases.Insert(faseSeleccionada - 1, fase);
                faseSeleccionada = Convert.ToInt32(cbxFase.Text);

                //Carga los datos de la fase seleccionada si es que tenia datos
                fase = fases[faseSeleccionada - 1];

                txtNombreFase.Text = Convert.ToString(fase.NombreFase);
                groupSize = fase.TamañoGrupos;
                groupAmount = fase.CantidadGrupos;
                if (fase.FechaFase == "" || fase.FechaFase == "DD/MM/YYYY")
                {
                    txtFechaFase.Text = "DD/MM/YYYY";
                    txtFechaFase.ForeColor = Color.DimGray;
                }
                else
                {
                    string fechaFase = fase.FechaFase;
                    try
                    {
                        if (CambiarFormatoFecha(fechaFase) == true)
                        {
                            fechaFase = fechaFase.Substring(0, fechaFase.Length - 8);
                        }
                    } catch { }
                    txtFechaFase.Text = fechaFase;
                    txtFechaFase.ForeColor = Color.Black;
                }

                if (fase.EquiposParticipantes != null)
                {
                    equiposFases = fase.EquiposParticipantes;
                }
                else { equiposFases = new List<EquiposFases>(); }

                if (fase.EncuentrosParticipantes != null)
                {
                    encuentrosFases = fase.EncuentrosParticipantes;
                }
                else { encuentrosFases = new List<EncuentrosFases>(); }

                if (fase.TipoFase == 0) { avoid = true; cbxTipoFase.SelectedIndex = 2; avoid = true; cbxTipoFase.SelectedIndex = 1; }
                else
                {
                    if (cbxTipoFase.Text == Convert.ToString(fase.TipoFase))
                    {
                        avoid = true;
                        cbxTipoFase.SelectedIndex = 2;
                        avoid = true;
                        cbxTipoFase.SelectedIndex = 1;
                    }
                    avoid = true;
                    cbxTipoFase.SelectedIndex = fase.TipoFase - 1;
                }
            } else
            {
                startModify = false;
            }
        }

        private void cbxTipoFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelEquipos.Controls.Clear();
            if (avoid == false)
            {
                Reset();
            }
            switch (cbxTipoFase.Text)
            {
                case "1": //LLaves //Actualmete no funcional
                    MessageBox.Show("Currently disabled, sorry for the inconvenience");
                    cbxTipoFase.SelectedIndex = 1;
                    return;
                    avoid = false;
                    btnLinkMatch.Hide();
                    btnLinkedMatchs.Hide();
                    tipoFase = 1;
                    int p = 8, count = 0, actuals = encuentrosFases.Count();
                    for (int t = 0; t < 4; t++)
                    {
                        for (int i = 0; i < p; i++)
                        {
                            Panel p1 = new Panel();

                            p1.Size = new Size(225, 50);
                            p1.BorderStyle = BorderStyle.None;
                            p1.BackColor = Color.FromArgb(255, 255, 248);
                            p1.TabIndex = 0;
                            p1.Location = new Point(275 * t, 75 * i);

                            Label lbl1 = new Label();

                            lbl1.Size = new Size(190, 15);
                            lbl1.Location = new Point(5, 16);
                            lbl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

                            TextBox txtID = new TextBox();
                            TextBox txtPos = new TextBox();
                            txtPos.Text = "" + t;

                            if (actuals > 0 && count < actuals)
                            {
                                if (encuentrosFases[count].PosicionEquipo == t)
                                {
                                    lbl1.Text = encuentrosFases[count].Nombre;
                                    txtID.Text = "" + encuentrosFases[count].IdEncuentro;
                                    count++;
                                }
                                else
                                {
                                    txtID.Text = "";
                                }
                            }
                            else
                            {
                                txtID.Text = "";
                            }

                            controls.Add(lbl1);
                            controls.Add(txtID);
                            controls.Add(txtPos);

                            PictureBox pic2 = new PictureBox(); //Boton agregar

                            pic2.BorderStyle = BorderStyle.FixedSingle;
                            pic2.Size = new Size(12, 12);
                            pic2.Location = new Point(200, 19);
                            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic2.Image = Properties.Resources.mas;
                            pic2.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID), controls.IndexOf(txtPos), false); };

                            panelEquipos.Controls.Add(p1);
                            p1.Controls.Add(pic2);
                            p1.Controls.Add(lbl1);
                        }
                        p /= 2;
                    }
                    break;
                case "2": //Grupos
                    btnLinkMatch.Show();
                    btnLinkedMatchs.Show();
                    tipoFase = 2;
                    Panel p3 = new Panel();

                    p3.Location = new Point(5, 60);
                    p3.Size = new Size(674, 208);
                    p3.AutoScroll = true;

                    Label lbl2 = new Label();

                    lbl2.Size = new Size(80, 15);
                    lbl2.Location = new Point(125, 5);
                    lbl2.Text = "Groups size";
                    lbl2.TabIndex = 1;

                    TextBox txtGroupSize = new TextBox();

                    txtGroupSize.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    txtGroupSize.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    txtGroupSize.Location = new Point(120, 30);
                    txtGroupSize.ReadOnly = true;
                    txtGroupSize.Size = new Size(27, 25);
                    txtGroupSize.Text = ""+groupSize;
                    txtGroupSize.TextAlign = HorizontalAlignment.Center;

                    Button btnSizePlus = new Button();

                    btnSizePlus.Location = new Point(152, 33);
                    btnSizePlus.Size = new Size(20, 20);
                    btnSizePlus.Text = "+";
                    btnSizePlus.TextAlign = ContentAlignment.TopCenter;
                    btnSizePlus.Click += (sender, EventArgs) => { Plus(sender, EventArgs, 2, txtGroupSize, p3); };

                    Button btnSizeMinus = new Button();

                    btnSizeMinus.Location = new Point(95, 33);
                    btnSizeMinus.Size = new Size(20, 20);
                    btnSizeMinus.Text = "-";
                    btnSizeMinus.TextAlign = ContentAlignment.TopCenter;
                    btnSizeMinus.Click += (sender, EventArgs) => { Minus(sender, EventArgs, 2, txtGroupSize, p3); };

                    Label lbl3 = new Label();

                    lbl2.Size = new Size(120, 15);
                    lbl2.Location = new Point(5, 5);
                    lbl2.Text = "Amount of groups";
                    lbl2.TabIndex = 1;

                    TextBox txtGroupAmount = new TextBox();

                    txtGroupAmount.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    txtGroupAmount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    txtGroupAmount.Location = new Point(30, 30);
                    txtGroupAmount.ReadOnly = true;
                    txtGroupAmount.Size = new Size(27, 25);
                    txtGroupAmount.Text = ""+groupAmount;
                    txtGroupAmount.TextAlign = HorizontalAlignment.Center;

                    Button btnAmountPlus = new Button();

                    btnAmountPlus.Location = new Point(62, 33);
                    btnAmountPlus.Size = new Size(20, 20);
                    btnAmountPlus.Text = "+";
                    btnAmountPlus.TextAlign = ContentAlignment.TopCenter;
                    btnAmountPlus.Click += (sender, EventArgs) => { Plus(sender, EventArgs, 1, txtGroupAmount, p3); };

                    Button btnAmountMinus = new Button();

                    btnAmountMinus.Location = new Point(5, 33);
                    btnAmountMinus.Size = new Size(20, 20);
                    btnAmountMinus.Text = "-";
                    btnAmountMinus.TextAlign = ContentAlignment.TopCenter;
                    btnAmountMinus.Click += (sender, EventArgs) => { Minus(sender, EventArgs, 1, txtGroupAmount, p3); };

                    panelEquipos.Controls.Add(btnAmountPlus);
                    panelEquipos.Controls.Add(btnAmountMinus);
                    panelEquipos.Controls.Add(btnSizeMinus);
                    panelEquipos.Controls.Add(btnSizePlus);
                    panelEquipos.Controls.Add(txtGroupAmount);
                    panelEquipos.Controls.Add(txtGroupSize);
                    panelEquipos.Controls.Add(lbl2);
                    panelEquipos.Controls.Add(lbl3);
                    panelEquipos.Controls.Add(p3);

                    if (avoid == false)
                    {
                        groupSize = 2;
                        groupAmount = 1;
                    }

                    PhasesGroups(p3);
                    break;
                case "3": //Desparejo
                    btnLinkMatch.Hide();
                    btnLinkedMatchs.Hide();
                    tipoFase = 3;
                    if (avoid != true)
                    {
                        groupSize = 2;
                        groupAmount = 2;
                    }
                    Panel p4 = new Panel();

                    p4.Location = new Point(5, 60);
                    p4.Size = new Size(674, 208);
                    p4.AutoScroll = true;

                    Label lbl4 = new Label();

                    lbl4.Size = new Size(120, 15);
                    lbl4.Location = new Point(5, 5);
                    lbl4.Text = "Amount of pairs";
                    lbl4.TabIndex = 1;

                    TextBox txtPairsAmount = new TextBox();

                    txtPairsAmount.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    txtPairsAmount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    txtPairsAmount.Location = new Point(30, 30);
                    txtPairsAmount.ReadOnly = true;
                    txtPairsAmount.Size = new Size(27, 25);
                    txtPairsAmount.Text = ""+groupAmount;
                    txtPairsAmount.TextAlign = HorizontalAlignment.Center;

                    Button btnAmountPPlus = new Button();

                    btnAmountPPlus.Location = new Point(62, 33);
                    btnAmountPPlus.Size = new Size(20, 20);
                    btnAmountPPlus.Text = "+";
                    btnAmountPPlus.TextAlign = ContentAlignment.TopCenter;
                    btnAmountPPlus.Click += (sender, EventArgs) => { Plus(sender, EventArgs, 1, txtPairsAmount, p4); };

                    Button btnAmountPMinus = new Button();

                    btnAmountPMinus.Location = new Point(5, 33);
                    btnAmountPMinus.Size = new Size(20, 20);
                    btnAmountPMinus.Text = "-";
                    btnAmountPMinus.TextAlign = ContentAlignment.TopCenter;
                    btnAmountPMinus.Click += (sender, EventArgs) => { Minus(sender, EventArgs, 1, txtPairsAmount, p4); };

                    panelEquipos.Controls.Add(lbl4);
                    panelEquipos.Controls.Add(p4);
                    panelEquipos.Controls.Add(txtPairsAmount);
                    panelEquipos.Controls.Add(btnAmountPPlus);
                    panelEquipos.Controls.Add(btnAmountPMinus);

                    PhasesGroups(p4);
                    break;
                case "4": //Posición
                    btnLinkMatch.Show();
                    btnLinkedMatchs.Show();
                    tipoFase = 4;
                    Panel p5 = new Panel();

                    p5.Location = new Point(5, 60);
                    p5.Size = new Size(674, 208);
                    p5.AutoScroll = true;

                    Label lbl5 = new Label();

                    lbl5.Size = new Size(80, 15);
                    lbl5.Location = new Point(5, 5);
                    lbl5.Text = "Groups size";
                    lbl5.TabIndex = 1;

                    TextBox txtTableSize = new TextBox();

                    txtTableSize.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    txtTableSize.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    txtTableSize.Location = new Point(30, 30);
                    txtTableSize.ReadOnly = true;
                    txtTableSize.Size = new Size(27, 25);
                    txtTableSize.Text = "2";
                    txtTableSize.TextAlign = HorizontalAlignment.Center;

                    Button btnSizeTPlus = new Button();

                    btnSizeTPlus.Location = new Point(62, 33);
                    btnSizeTPlus.Size = new Size(20, 20);
                    btnSizeTPlus.Text = "+";
                    btnSizeTPlus.TextAlign = ContentAlignment.TopCenter;
                    btnSizeTPlus.Click += (sender, EventArgs) => { Plus(sender, EventArgs, 2, txtTableSize, p5); };

                    Button btnSizeTMinus = new Button();

                    btnSizeTMinus.Location = new Point(5, 33);
                    btnSizeTMinus.Size = new Size(20, 20);
                    btnSizeTMinus.Text = "-";
                    btnSizeTMinus.TextAlign = ContentAlignment.TopCenter;
                    btnSizeTMinus.Click += (sender, EventArgs) => { Minus(sender, EventArgs, 2, txtTableSize, p5); };

                    panelEquipos.Controls.Add(lbl5);
                    panelEquipos.Controls.Add(p5);
                    panelEquipos.Controls.Add(txtTableSize);
                    panelEquipos.Controls.Add(btnSizeTPlus);
                    panelEquipos.Controls.Add(btnSizeTMinus);

                    if (avoid != true)
                    {
                        groupSize = 2;
                        groupAmount = 1;
                    }

                    PhasesGroups(p5);
                    break;
                case "5": //Eliminatorias
                    btnLinkMatch.Show();
                    btnLinkedMatchs.Show();
                    tipoFase = 5;
                    Panel p6 = new Panel();

                    p6.Location = new Point(5, 60);
                    p6.Size = new Size(674, 208);
                    p6.AutoScroll = true;

                    Label lbl6 = new Label();

                    lbl6.Size = new Size(80, 15);
                    lbl6.Location = new Point(5, 5);
                    lbl6.Text = "Groups size";
                    lbl6.TabIndex = 1;

                    TextBox txtTableESize = new TextBox();

                    txtTableESize.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    txtTableESize.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                    txtTableESize.Location = new Point(30, 30);
                    txtTableESize.ReadOnly = true;
                    txtTableESize.Size = new Size(27, 25);
                    txtTableESize.Text = "2";
                    txtTableESize.TextAlign = HorizontalAlignment.Center;

                    Button btnSizeEPlus = new Button();

                    btnSizeEPlus.Location = new Point(62, 33);
                    btnSizeEPlus.Size = new Size(20, 20);
                    btnSizeEPlus.Text = "+";
                    btnSizeEPlus.TextAlign = ContentAlignment.TopCenter;
                    btnSizeEPlus.Click += (sender, EventArgs) => { Plus(sender, EventArgs, 2, txtTableESize, p6); };

                    Button btnSizeEMinus = new Button();

                    btnSizeEMinus.Location = new Point(5, 33);
                    btnSizeEMinus.Size = new Size(20, 20);
                    btnSizeEMinus.Text = "-";
                    btnSizeEMinus.TextAlign = ContentAlignment.TopCenter;
                    btnSizeEMinus.Click += (sender, EventArgs) => { Minus(sender, EventArgs, 2, txtTableESize, p6); };

                    panelEquipos.Controls.Add(lbl6);
                    panelEquipos.Controls.Add(p6);
                    panelEquipos.Controls.Add(txtTableESize);
                    panelEquipos.Controls.Add(btnSizeEPlus);
                    panelEquipos.Controls.Add(btnSizeEMinus);

                    if (avoid != true)
                    {
                        groupSize = 2;
                        groupAmount = 1;
                    }

                    PhasesGroups(p6);
                    break;
            }
        }

        private void btnminusFases_Click(object sender, EventArgs e)
        {
            if (cantFases > 1)
            {
                cbxFase.Items.Remove(cantFases);
                cantFases -= 1;
                txtCantFases.Text = "" + cantFases;
                fases.RemoveAt(cantFases);
            } else
            {
                MessageBox.Show("There can't be less than one phase");
            }
        }

        private void btnPlusFases_Click(object sender, EventArgs e)
        {
            cantFases += 1;
            txtCantFases.Text = "" + cantFases;
            cbxFase.Items.Add(cantFases);
            fases.Add(new Fase());
        }

        private void btnEventCerrar_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                Close();
            }
            else
            {
                Hide();
                MenuManageEvents manageEvents = new MenuManageEvents();
                manageEvents.StartPosition = FormStartPosition.CenterParent;
                manageEvents.ShowDialog();
                Close();
            }
        }

        private void btnGoFases_Click(object sender, EventArgs e)
        {
            panelFases.Show();
            panelEvent.Hide();
        }

        private void btnGoEvent_Click(object sender, EventArgs e)
        {
            panelFases.Hide();
            panelEvent.Show();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagenCargada = new Bitmap(open.FileName);
                    int wid = imagenCargada.Width;
                    int hei = imagenCargada.Height;
                    if (wid == 150 || hei == 150)
                    {
                        imgEventSelected.Image = imagenCargada;
                    }
                    else
                    {
                        imagenCargada = null;
                        imgEventSelected.Image = null;
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The image must be of the size of 150x150 pixels");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("La imagen debe ser de la medida de 150x150 pixeles");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void txtFecha_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "DD/MM/YYYY")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtFecha_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "DD/MM/YYYY";
                t.ForeColor = Color.DimGray;
            }
        }

        private void txtHora_Enter(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "XX:XX")
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void txtHora_Leave(object sender, EventArgs e, TextBox t)
        {
            if (t.Text == "")
            {
                t.Text = "XX:XX";
                t.ForeColor = Color.DimGray;
            }
        }

        private void LookTeam_Click(object sender, EventArgs e, int lblI, int txtId, int txtPos, bool enc)
        {
            panelBuscadorEquipos.Controls.Clear();
            panelBuscadorEquipos.Show();
            this.lblId = lblI;
            this.txtId = txtId;
            this.txtPos = txtPos;

            TextBox buscador = new TextBox();

            buscador.Size = new Size(250, 26);
            buscador.Location = new Point(39, 20);
            buscador.BorderStyle = BorderStyle.FixedSingle;

            Button btnBuscar = new Button();

            btnBuscar.Size = new Size(25, 25);
            btnBuscar.Location = new Point(289, 20);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = Properties.Resources.lupa;

            Panel panelPrincipal = new Panel();

            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Location = new Point(0, 75);
            panelPrincipal.Size = new Size(352, 237);

            Panel panelLabels = new Panel();

            panelLabels.BorderStyle = BorderStyle.FixedSingle;
            panelLabels.Location = new Point(0, 0);
            panelLabels.Size = new Size(352, 25);

            Label lblId = new Label();

            lblId.Text = "ID";
            lblId.Size = new Size(40, 25);
            lblId.Location = new Point(0, 0);
            lblId.BorderStyle = BorderStyle.FixedSingle;
            lblId.TextAlign = ContentAlignment.MiddleCenter;

            Label lblEquipo = new Label();

            lblEquipo.Text = "Equipo";
            lblEquipo.Size = new Size(200, 25);
            lblEquipo.Location = new Point(40, 0);
            lblEquipo.BorderStyle = BorderStyle.FixedSingle;
            lblEquipo.TextAlign = ContentAlignment.MiddleCenter;

            Label lblOrigen = new Label();

            lblOrigen.Text = "País de origen";
            lblOrigen.Size = new Size(112, 25);
            lblOrigen.Location = new Point(240, 0);
            lblOrigen.BorderStyle = BorderStyle.FixedSingle;
            lblOrigen.TextAlign = ContentAlignment.MiddleCenter;

            Panel panelContenedor = new Panel();

            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Location = new Point(0, 25);
            panelContenedor.Size = new Size(352, 222);
            panelContenedor.AutoScroll = true;

            Button btnCerrar = new Button();

            btnCerrar.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderColor = Color.DimGray;
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            btnCerrar.Location = new Point(325, 4);
            btnCerrar.Size = new Size(21, 21);
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += new EventHandler(btnCerrarBuscador_Click);

            Button btn1 = new Button();

            btn1.Size = new Size(80, 20);
            btn1.Location = new Point(136, 50);
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btn1.Text = "Add";

            btnBuscar.Click += (sender, EventArgs) => { BuscarEquipo(sender, EventArgs, buscador.Text, panelContenedor, enc); };

            panelBuscadorEquipos.Controls.Add(panelPrincipal);
            panelBuscadorEquipos.Controls.Add(buscador);
            panelBuscadorEquipos.Controls.Add(btnBuscar);
            panelBuscadorEquipos.Controls.Add(btn1);
            panelBuscadorEquipos.Controls.Add(btnCerrar);
            panelPrincipal.Controls.Add(panelLabels);
            panelPrincipal.Controls.Add(panelContenedor);
            panelLabels.Controls.Add(lblEquipo);
            panelLabels.Controls.Add(lblOrigen);
            panelLabels.Controls.Add(lblId);

            if (enc == true)
            {
                var encuentros = Logica.GetEncuentros(1, null);

                foreach (var en in encuentros)
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 0);
                    p1.Size = new Size(334, 25);
                    p1.Dock = DockStyle.Top;

                    Label lbl1 = new Label();

                    lbl1.Text = "" + en.IdEncuentro;
                    lbl1.Size = new Size(40, 25);
                    lbl1.Location = new Point(0, 0);
                    lbl1.BorderStyle = BorderStyle.FixedSingle;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl2 = new Label();

                    lbl2.Text = "" + en.Nombre;
                    lbl2.Size = new Size(200, 25);
                    lbl2.Location = new Point(40, 0);
                    lbl2.BorderStyle = BorderStyle.FixedSingle;
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl3 = new Label();

                    lbl3.Text = "" + en.Fecha;
                    lbl3.Size = new Size(82, 25);
                    lbl3.Location = new Point(240, 0);
                    lbl3.BorderStyle = BorderStyle.FixedSingle;
                    lbl3.AutoSize = false;
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;

                    Button btn2 = new Button();

                    btn2.BackColor = Color.Red;
                    btn2.Size = new Size(12, 12);
                    btn2.Location = new Point(322, 7);
                    btn2.FlatStyle = FlatStyle.Flat;
                    btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, en.Nombre, en.IdEncuentro, true); };

                    panelContenedor.Controls.Add(p1);
                    p1.Controls.Add(btn2);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);
                }
                btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, encName, encId, enc); };
            }
            else
            {
                if (tipoFase == 2 || tipoFase == 4 || tipoFase == 5)
                {
                    var equipos = Logica.GetEquipos(1, null);

                    foreach (var eq in equipos)
                    {
                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 0);
                        p1.Size = new Size(334, 25);
                        p1.Dock = DockStyle.Top;

                        Label lbl1 = new Label();

                        lbl1.Text = "" + eq.IdEquipo;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = eq.NombreEquipo;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + eq.PaisOrigen;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.AutoSize = false;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn2 = new Button();

                        btn2.BackColor = Color.Red;
                        btn2.Size = new Size(12, 12);
                        btn2.Location = new Point(322, 7);
                        btn2.FlatStyle = FlatStyle.Flat;
                        btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, eq.NombreEquipo, eq.IdEquipo, false); };

                        panelContenedor.Controls.Add(p1);
                        p1.Controls.Add(btn2);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);
                    }
                    btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, eqName, eqId, enc); };
                }
                else if (tipoFase == 1 || tipoFase == 3)
                {
                    enc = true;
                    var encuentros = Logica.GetEncuentros(1, null);

                    foreach (var en in encuentros)
                    {
                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 0);
                        p1.Size = new Size(334, 25);
                        p1.Dock = DockStyle.Top;

                        Label lbl1 = new Label();

                        lbl1.Text = "" + en.IdEncuentro;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = en.Nombre;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + en.Fecha;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.AutoSize = false;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn2 = new Button();

                        btn2.BackColor = Color.Red;
                        btn2.Size = new Size(12, 12);
                        btn2.Location = new Point(322, 7);
                        btn2.FlatStyle = FlatStyle.Flat;
                        btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, en.Nombre, en.IdEncuentro, true); };

                        panelContenedor.Controls.Add(p1);
                        p1.Controls.Add(btn2);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);
                    }
                    btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, encName, encId, enc); };
                }
            }
        }

        private void BtnChange(object sender, EventArgs e, Button b, Panel p, string name, int id, bool enc)
        {
            List<Panel> panels = new List<Panel>();
            List<Button> buttons = new List<Button>();
            foreach(var pan in p.Controls)
            {
                if (pan is Panel)
                {
                    Panel pa = pan as Panel;
                    panels.Add(pa);
                }
            }
            foreach (var pan in panels)
            {
                foreach (var bu in pan.Controls)
                {
                    if (bu is Button)
                    {
                        Button but = bu as Button;
                        buttons.Add(but);
                    }
                }
            }
            foreach (Button bu in buttons)
            {
                bu.BackColor = Color.Red;
            }
            b.BackColor = Color.Green;
            if (enc == true)
            {
                encName = name;
                encId = id;
            } else
            {
                eqName = name;
                eqId = id;
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e) //Agrega todos los datos del evento a la BD
        {
            if (modify == false)
            {
                Fase fase = new Fase();
                fase.NumeroFase = faseSeleccionada;
                fase.FechaFase = txtFechaFase.Text;
                fase.NombreFase = txtNombreFase.Text;
                fase.TipoFase = Convert.ToInt32(cbxTipoFase.Text);
                fase.EquiposParticipantes = equiposFases;
                fase.EncuentrosParticipantes = encuentrosFases;
                fase.EstadoFase = cbxEstadoFase.Text;
                fase.TamañoGrupos = groupSize;
                fase.CantidadGrupos = groupAmount;

                fases.RemoveAt(faseSeleccionada - 1);
                fases.Insert(faseSeleccionada - 1, fase);

                try
                {
                    string[] fechaEventoArray = txtFechaEvento.Text.Split("/");
                    string fechaEvento = fechaEventoArray[2] + "-" + fechaEventoArray[1] + "-" + fechaEventoArray[0];

                    string nombreEvento = txtNombreEvento.Text,
                           horaEvento = txtHoraEvento.Text,
                           estadoEvento = cbxEstadoEvento.Text,
                           lugar = txtlugarEvento.Text;
                    Bitmap imagenEvento = new Bitmap(imagenCargada);

                    Directory.CreateDirectory(@"C:\Certus\SRD\Eventos");
                    string FilePath = $@"C:\\Certus\\SRD\\Eventos\\{nombreEvento + lugar + fechaEvento}.bmp";
                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            imagenEvento.Save(memory, ImageFormat.Bmp);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }

                    Logica.InsertEvento(nombreEvento, fechaEvento, horaEvento, estadoEvento, lugar, FilePath);

                    int idEvento = Logica.GetEventos(3, nombreEvento)[0].IdEvento;

                    foreach (var f in fases)
                    {
                        string[] fechaFaseArray = f.FechaFase.Split("/");
                        string fechaFase = fechaFaseArray[2] + "-" + fechaFaseArray[1] + "-" + fechaFaseArray[0];

                        Logica.InsertFase(f.NumeroFase, idEvento, f.EstadoFase, f.NombreFase, fechaFase, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);

                        foreach(var eqF in f.EquiposParticipantes)
                        {
                            Equipo eq = Logica.GetEquipos(3, ""+eqF.IdEquipo)[0];

                            Logica.InsertEquiposFases(eq.IdEquipo, f.NumeroFase, idEvento, eq.ImagenRepresentativa,
                                eq.PaisOrigen, eq.NombreEquipo, eqF.EstadoEquipo, eqF.PosicionEquipo, eqF.Puntaje,
                                eq.TipoEquipo, f.EstadoFase, f.NombreFase, fechaFase, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);
                        }
                        foreach(var enF in f.EncuentrosParticipantes)
                        {
                            Encuentro en = Logica.GetEncuentros(4, ""+enF.IdEncuentro)[0];

                            Logica.InsertEncuentrosFases(en.IdEncuentro, f.NumeroFase, idEvento, en.IdDeporte, en.IdCategoria, en.IdPersona, en.Hora, en.Lugar, en.Fecha, en.Nombre, en.Estado, en.Clima, en.TipoEncuentro, f.EstadoFase, f.NombreFase, fechaFase, f.TipoFase, enF.Puntaje, enF.PosicionEquipo, f.TamañoGrupos, f.CantidadGrupos);
                        }
                    }

                    MessageBox.Show("Event added correctly");
                    Hide();
                    MainMenu main = new MainMenu();
                    main.StartPosition = FormStartPosition.CenterParent;
                    main.ShowDialog();
                    Close();
                } catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return; }
            } else
            {
                if (txtFechaEvento.Text != "" && txtFechaFase.Text != "" && txtHoraEvento.Text != "" && txtlugarEvento.Text != "" && txtNombreEvento.Text != "" && txtNombreFase.Text != "")
                {
                    DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify event", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        try
                        {
                            string[] fechaFaseArray = txtFechaFase.Text.Split("/");
                            string fechaFase = fechaFaseArray[2] + "-" + fechaFaseArray[1] + "-" + fechaFaseArray[0];

                            Fase fase = new Fase();
                            fase.NumeroFase = faseSeleccionada;
                            fase.FechaFase = fechaFase;
                            fase.NombreFase = txtNombreFase.Text;
                            fase.TipoFase = Convert.ToInt32(cbxTipoFase.Text);
                            fase.EquiposParticipantes = equiposFases;
                            fase.EncuentrosParticipantes = encuentrosFases;
                            fase.EstadoFase = cbxEstadoFase.Text;
                            fase.TamañoGrupos = groupSize;
                            fase.CantidadGrupos = groupAmount;

                            fases.RemoveAt(faseSeleccionada - 1);
                            fases.Insert(faseSeleccionada - 1, fase);


                            string[] fechaEventoArray = txtFechaEvento.Text.Split("/");
                            string fechaEvento = fechaEventoArray[2] + "-" + fechaEventoArray[1] + "-" + fechaEventoArray[0];

                            string nombreEvento = txtNombreEvento.Text,
                                   horaEvento = txtHoraEvento.Text,
                                   estadoEvento = cbxEstadoEvento.Text,
                                   lugar = txtlugarEvento.Text;
                            Bitmap imagenEvento = new Bitmap(imagenCargada);

                            Directory.CreateDirectory(@"C:\Certus\SRD\Eventos");
                            string FilePath = $@"C:\\Certus\\SRD\\Eventos\\{nombreEvento + lugar + fechaEvento}.bmp";
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    imagenEvento.Save(memory, ImageFormat.Bmp);
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }

                            Logica.UpdateEvento(index, nombreEvento, fechaEvento, horaEvento, estadoEvento, lugar, FilePath);

                            int idEvento = Logica.GetEventos(3, nombreEvento)[0].IdEvento;

                            foreach (var f in fases)
                            {
                                string fechaFase1 = f.FechaFase;
                                try
                                {
                                    string[] fechaFaseArray1 = fechaFase1.Split("/");
                                    fechaFase1 = fechaFaseArray1[2] + "-" + fechaFaseArray1[1] + "-" + fechaFaseArray1[0];
                                }
                                catch { }

                                if (Logica.CheckIfExist("Fases", "NumeroFase", "" + f.NumeroFase, "IdEvento", "" + idEvento) == 1)
                                {
                                    Logica.UpdateFase(f.NumeroFase, idEvento, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);

                                    foreach (var eqF in f.EquiposParticipantes)
                                    {
                                        Equipo eq = Logica.GetEquipos(3, "" + eqF.IdEquipo)[0];

                                        if (Logica.CheckIfExist("EquiposFases", "NumeroFase", "" + f.NumeroFase, "IdEvento", "" + idEvento, "IdEquipo", "" + eqF.IdEquipo) == 1)
                                        {
                                            Logica.UpdateEquiposFases(eq.IdEquipo, f.NumeroFase, idEvento, eq.ImagenRepresentativa,
                                            eq.PaisOrigen, eq.NombreEquipo, eqF.EstadoEquipo, eqF.PosicionEquipo, eqF.Puntaje,
                                            eq.TipoEquipo, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);
                                        }
                                        else
                                        {
                                            Logica.InsertEquiposFases(eq.IdEquipo, f.NumeroFase, idEvento, eq.ImagenRepresentativa,
                                            eq.PaisOrigen, eq.NombreEquipo, eqF.EstadoEquipo, eqF.PosicionEquipo, eqF.Puntaje,
                                            eq.TipoEquipo, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);
                                        }
                                    }
                                    foreach (var enF in f.EncuentrosParticipantes)
                                    {
                                        Encuentro en = Logica.GetEncuentros(4, "" + enF.IdEncuentro)[0];

                                        if (Logica.CheckIfExist("EncuentrosFases", "NumeroFase", "" + f.NumeroFase, "IdEvento", "" + idEvento, "IdEncuentro", "" + enF.IdEncuentro) == 1)
                                        {
                                            Logica.UpdateEncuentrosFases(en.IdEncuentro, f.NumeroFase, idEvento, en.IdDeporte, en.IdCategoria, en.IdPersona, en.Hora, en.Lugar, en.Fecha, en.Nombre, en.Estado, en.Clima, en.TipoEncuentro, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, enF.Puntaje, enF.PosicionEquipo, f.TamañoGrupos, f.CantidadGrupos);
                                        }
                                        else
                                        {
                                            Logica.InsertEncuentrosFases(en.IdEncuentro, f.NumeroFase, idEvento, en.IdDeporte, en.IdCategoria, en.IdPersona, en.Hora, en.Lugar, en.Fecha, en.Nombre, en.Estado, en.Clima, en.TipoEncuentro, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, enF.Puntaje, enF.PosicionEquipo, f.TamañoGrupos, f.CantidadGrupos);
                                        }
                                    }
                                }
                                else
                                {
                                    Logica.InsertFase(f.NumeroFase, idEvento, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);

                                    foreach (var eqF in f.EquiposParticipantes)
                                    {
                                        Equipo eq = Logica.GetEquipos(3, "" + eqF.IdEquipo)[0];

                                        Logica.InsertEquiposFases(eq.IdEquipo, f.NumeroFase, idEvento, eq.ImagenRepresentativa,
                                            eq.PaisOrigen, eq.NombreEquipo, eqF.EstadoEquipo, eqF.PosicionEquipo, eqF.Puntaje,
                                            eq.TipoEquipo, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, f.TamañoGrupos, f.CantidadGrupos);
                                    }
                                    foreach (var enF in f.EncuentrosParticipantes)
                                    {
                                        Encuentro en = Logica.GetEncuentros(4, "" + enF.IdEncuentro)[0];

                                        Logica.InsertEncuentrosFases(en.IdEncuentro, f.NumeroFase, idEvento, en.IdDeporte, en.IdCategoria, en.IdPersona, en.Hora, en.Lugar, en.Fecha, en.Nombre, en.Estado, en.Clima, en.TipoEncuentro, f.EstadoFase, f.NombreFase, fechaFase1, f.TipoFase, enF.Puntaje, enF.PosicionEquipo, f.TamañoGrupos, f.CantidadGrupos);
                                    }
                                }
                            }

                            MessageBox.Show("Event modified correctly");
                            Hide();
                            MenuManageEvents manageEvents = new MenuManageEvents();
                            manageEvents.StartPosition = FormStartPosition.CenterParent;
                            manageEvents.ShowDialog();
                            Close();
                        } catch (Exception ex) { MessageBox.Show("Error: "+ex.Message); return; }
                    }
                }
                else
                {
                    if (Program.language == "EN")
                    {
                        MessageBox.Show("There are filds incomplete");
                    }
                    else if (Program.language == "ES")
                    {
                        MessageBox.Show("Quedan espacios vacios por rellenar");
                    }
                }
            }
        }

        private void BuscarEquipo(object sender, EventArgs e, string busqueda, Panel p, bool enc)
        {
            p.Controls.Clear();

            if (enc == true)
            {
                var encuentros = Logica.GetEncuentros(2, busqueda);

                foreach (var en in encuentros)
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 0);
                    p1.Size = new Size(334, 25);
                    p1.Dock = DockStyle.Top;

                    Label lbl1 = new Label();

                    lbl1.Text = "" + en.IdEncuentro;
                    lbl1.Size = new Size(40, 25);
                    lbl1.Location = new Point(0, 0);
                    lbl1.BorderStyle = BorderStyle.FixedSingle;
                    lbl1.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl2 = new Label();

                    lbl2.Text = en.Nombre;
                    lbl2.Size = new Size(200, 25);
                    lbl2.Location = new Point(40, 0);
                    lbl2.BorderStyle = BorderStyle.FixedSingle;
                    lbl2.TextAlign = ContentAlignment.MiddleCenter;

                    Label lbl3 = new Label();

                    lbl3.Text = "" + en.Fecha;
                    lbl3.Size = new Size(82, 25);
                    lbl3.Location = new Point(240, 0);
                    lbl3.BorderStyle = BorderStyle.FixedSingle;
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;

                    Button btn1 = new Button();

                    btn1.Size = new Size(12, 12);
                    btn1.Location = new Point(322, 7);
                    btn1.FlatStyle = FlatStyle.Flat;
                    btn1.BackgroundImageLayout = ImageLayout.Stretch;
                    btn1.BackgroundImage = Properties.Resources.mas;
                    btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, en.Nombre, en.IdEncuentro, enc); };

                    p.Controls.Add(p1);
                    p1.Controls.Add(btn1);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);
                }
            }
            else
            {
                if (tipoFase == 2 || tipoFase == 4 || tipoFase == 5)
                {
                    var equipos = Logica.GetEquipos(2, busqueda);

                    foreach (var eq in equipos)
                    {
                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 0);
                        p1.Size = new Size(334, 25);
                        p1.Dock = DockStyle.Top;

                        Label lbl1 = new Label();

                        lbl1.Text = "" + eq.IdEquipo;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = eq.NombreEquipo;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + eq.PaisOrigen;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn1 = new Button();

                        btn1.Size = new Size(12, 12);
                        btn1.Location = new Point(322, 7);
                        btn1.FlatStyle = FlatStyle.Flat;
                        btn1.BackgroundImageLayout = ImageLayout.Stretch;
                        btn1.BackgroundImage = Properties.Resources.mas;
                        btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, eq.NombreEquipo, eq.IdEquipo, enc); };

                        p.Controls.Add(p1);
                        p1.Controls.Add(btn1);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);
                    }
                }
                else if (tipoFase == 1 || tipoFase == 3)
                {
                    var encuentros = Logica.GetEncuentros(2, busqueda);
                    enc = true;

                    foreach (var en in encuentros)
                    {
                        Panel p1 = new Panel();

                        p1.Location = new Point(0, 0);
                        p1.Size = new Size(334, 25);
                        p1.Dock = DockStyle.Top;

                        Label lbl1 = new Label();

                        lbl1.Text = "" + en.IdEncuentro;
                        lbl1.Size = new Size(40, 25);
                        lbl1.Location = new Point(0, 0);
                        lbl1.BorderStyle = BorderStyle.FixedSingle;
                        lbl1.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl2 = new Label();

                        lbl2.Text = en.Nombre;
                        lbl2.Size = new Size(200, 25);
                        lbl2.Location = new Point(40, 0);
                        lbl2.BorderStyle = BorderStyle.FixedSingle;
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbl3 = new Label();

                        lbl3.Text = "" + en.Fecha;
                        lbl3.Size = new Size(82, 25);
                        lbl3.Location = new Point(240, 0);
                        lbl3.BorderStyle = BorderStyle.FixedSingle;
                        lbl3.TextAlign = ContentAlignment.MiddleCenter;

                        Button btn1 = new Button();

                        btn1.Size = new Size(12, 12);
                        btn1.Location = new Point(322, 7);
                        btn1.FlatStyle = FlatStyle.Flat;
                        btn1.BackgroundImageLayout = ImageLayout.Stretch;
                        btn1.BackgroundImage = Properties.Resources.mas;
                        btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, en.Nombre, en.IdEncuentro, enc); };

                        p.Controls.Add(p1);
                        p1.Controls.Add(btn1);
                        p1.Controls.Add(lbl3);
                        p1.Controls.Add(lbl2);
                        p1.Controls.Add(lbl1);
                    }
                }
            }
        }

        private void btnCerrarBuscador_Click(object sender, EventArgs e)
        {
            panelBuscadorEquipos.Hide();
        }

        private void btnCerrarEncuentros_Click(object sender, EventArgs e)
        {
            panelEncuentros.Hide();
        }

        private void DeleteTeam_Click(object sender, EventArgs e)
        {
            equiposFases.Clear();
            encuentrosFases.Clear();
            cbxTipoFase_SelectedIndexChanged(sender, e);
        }

        private void Reset()
        {
            equiposFases.Clear();
            encuentrosFases.Clear();
        }

        private void AddTeam(object sender, EventArgs e, string name, int id, bool enc)
        {
            if (enc == true)
            {
                if (tipoFase == 1 || tipoFase == 3)
                {
                    var lbl1 = controls[lblId];
                    var txt = controls[txtId];
                    lbl1.Text = name;
                    txt.Text = "" + id;
                }
                if (tipoFase == 1)
                {
                    int pos = Convert.ToInt32(controls[txtPos].Text);
                    encuentrosFases.Add(new EncuentrosFases() { IdEncuentro = id, Nombre = name, NumeroFase = faseSeleccionada, PosicionEquipo = pos });
                } else
                {
                    encuentrosFases.Add(new EncuentrosFases() { IdEncuentro = id, Nombre = name, NumeroFase = faseSeleccionada });
                }
            } else
            {
                var lbl1 = controls[lblId];
                var txt = controls[txtId];
                lbl1.Text = name;
                txt.Text = "" + id;
                equiposFases.Add(new EquiposFases() { IdEquipo = id, NombreEquipo = name, NumeroFase = faseSeleccionada });
            }

            panelBuscadorEquipos.Hide();
        }

        private void Plus(object sender, EventArgs e, int n, TextBox t, Panel p)
        {
            switch(n)
            {
                case 1:
                    groupAmount += 1;
                    t.Text = "" + groupAmount;
                    break;
                case 2:
                    groupSize += 1;
                    t.Text = "" + groupSize;
                    break;
            }
            PhasesGroups(p);
        }

        private void Minus(object sender, EventArgs e, int n, TextBox t, Panel p)
        {
            if (t.Text == "1")
            {
                MessageBox.Show("It can't be less than one");
            }
            else
            {
                switch (n)
                {
                    case 1:
                        groupAmount -= 1;
                        t.Text = "" + groupAmount;
                        break;
                    case 2:
                        groupSize -= 1;
                        t.Text = "" + groupSize;
                        break;
                }
                PhasesGroups(p);
            }
        }

        private void btnListEncuentros_Click(object sender, EventArgs e)
        {
            panelContenedorEncuentros.Controls.Clear();
            panelEncuentros.Show();

            foreach(var enF in encuentrosFases)
            {
                var encuentro = Logica.GetEncuentros(4, ""+enF.IdEncuentro)[0];

                Panel p1 = new Panel(); //Crea el panel donde apareceran los controles

                p1.Dock = DockStyle.Top;
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.Size = new Size(290, 25);
                p1.TabIndex = 0;

                Label l2 = new Label(); //Nombre del encuentro

                l2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.Size = new Size(258, 25);
                l2.AutoSize = false;
                l2.BackColor = Color.FromArgb(255, 255, 248);
                l2.BorderStyle = BorderStyle.FixedSingle;
                l2.Location = new Point(0, 0);
                l2.Text = encuentro.Nombre;

                PictureBox pic1 = new PictureBox(); //Boton eliminar

                pic1.BorderStyle = BorderStyle.FixedSingle;
                pic1.Size = new Size(12, 12);
                pic1.Location = new Point(258, 7);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Properties.Resources.cruz;
                pic1.Click += (sender, EventArgs) => { Delete_Click(sender, EventArgs, encuentro, p1); };

                panelContenedorEncuentros.Controls.Add(p1); //Agrega los controles al panelDeportesContenedor
                p1.Controls.Add(pic1);
                p1.Controls.Add(l2);
            }
        }

        private void Delete_Click(object sender, EventArgs e, Encuentro enc, Panel p)
        {
            encuentrosFases.RemoveAll(r => r.IdEncuentro == enc.IdEncuentro);
            p.Dispose();
        }

        private void PhasesGroups(Panel p)
        {
            p.Controls.Clear();
            if (avoid == true)
            {
                avoid = false;
            }
            else
            {
                Reset();
            }
            int x = 0, y = 0, count = 0;
            for (int i = 1; i < groupAmount + 1; i++)
            {
                Panel p1 = new Panel();

                p1.Size = new Size(225, 25);
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.BackColor = Color.FromArgb(255, 255, 248);
                p1.TabIndex = 0;
                p1.Location = new Point(x, y);

                Label lbl2 = new Label();

                lbl2.Size = new Size(225, 25);
                lbl2.Location = new Point(0, 0);
                lbl2.TextAlign = ContentAlignment.MiddleCenter;
                lbl2.Text = "Group " +(i);

                p.Controls.Add(p1);
                p1.Controls.Add(lbl2);

                if (tipoFase == 3)
                {
                    Panel p2 = new Panel();

                    p2.Size = new Size(225, 50);
                    p2.BorderStyle = BorderStyle.FixedSingle;
                    p2.BackColor = Color.FromArgb(255, 255, 248);
                    p2.TabIndex = 0;
                    p2.Location = new Point(x, y + 25);

                    Label lbl1 = new Label();

                    lbl1.Size = new Size(190, 20);
                    lbl1.Location = new Point(5, 16);
                    lbl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

                    TextBox txtID = new TextBox();

                    txtID.Text = "";

                    if (count < encuentrosFases.Count())
                    {
                        txtID.Text = "" + encuentrosFases[count].IdEncuentro;
                        lbl1.Text = encuentrosFases[count].Nombre;
                        count++;
                    }

                    controls.Add(lbl1);
                    controls.Add(txtID);

                    PictureBox pic2 = new PictureBox(); //Boton agregar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(200, 19);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.mas;
                    pic2.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID), 0, true); };

                    p.Controls.Add(p2);
                    p2.Controls.Add(lbl1);
                    p2.Controls.Add(pic2);
                }
                else
                {
                    for (int j = 1; j < groupSize + 1; j++)
                    {
                        Panel p2 = new Panel();

                        p2.Size = new Size(225, 25);
                        p2.BorderStyle = BorderStyle.FixedSingle;
                        p2.BackColor = Color.FromArgb(255, 255, 248);
                        p2.TabIndex = 0;
                        p2.Location = new Point(x, y + 25 * j);

                        Label lbl1 = new Label();

                        lbl1.Size = new Size(190, 15);
                        lbl1.Location = new Point(5, 5);

                        TextBox txtID = new TextBox();

                        txtID.Text = "";

                        if (tipoFase == 4)
                        {
                            CheckBox chk = new CheckBox();

                            chk.Size = new Size(12, 12);
                            chk.Location = new Point(186, 7);
                            chk.FlatStyle = FlatStyle.Flat;
                            chk.CheckedChanged += (sender, EventArgs) => { EliminateTeam(sender, EventArgs, controls.IndexOf(txtID), chk.Checked); };


                            if (count < equiposFases.Count())
                            {
                                if (equiposFases[count].EstadoEquipo == "Eliminated")
                                {
                                    chk.CheckState = CheckState.Checked;
                                }
                            }

                            lbl1.Size = new Size(185, 15);
                            p2.Controls.Add(chk);

                        } else if (tipoFase == 5)
                        {
                            TextBox txtPosicion = new TextBox();

                            txtPosicion.Size = new Size(30, 15);
                            txtPosicion.Location = new Point(169, 0);
                            txtPosicion.Leave += (sender, EventArgs) => { ChangeTeamPosition(sender, EventArgs, controls.IndexOf(txtID), txtPosicion.Text); };

                            if (modify == true)
                            {
                                if (count < equiposFases.Count())
                                {
                                    txtPosicion.Text = "" + equiposFases[count].PosicionEquipo;
                                }
                            }

                            lbl1.Size = new Size(168, 15);
                            p2.Controls.Add(txtPosicion);
                        }

                        if (count < equiposFases.Count())
                        {
                            txtID.Text = "" + equiposFases[count].IdEquipo;
                            lbl1.Text = equiposFases[count].NombreEquipo;
                            count++;
                        }

                        controls.Add(lbl1);
                        controls.Add(txtID);

                        PictureBox pic2 = new PictureBox(); //Boton agregar

                        pic2.BorderStyle = BorderStyle.FixedSingle;
                        pic2.Size = new Size(12, 12);
                        pic2.Location = new Point(200, 7);
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.Image = Properties.Resources.mas;
                        pic2.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID), 0, false); };

                        p.Controls.Add(p2);
                        p2.Controls.Add(lbl1);
                        p2.Controls.Add(pic2);
                    }
                }
                if (i % 2 != 0 || i == 1)
                {
                    y = (groupSize + 1) * 25 + 50;
                }
                else
                {
                    y = 0; x += 250;
                }
            }
        }

        private void EliminateTeam(object sender, EventArgs e, int txtId, bool check)
        {
            try
            {
                int id = Convert.ToInt32(controls[txtId].Text);
                var eq = equiposFases.Find(r => r.IdEquipo == id);
                if (check == true)
                {
                    eq.EstadoEquipo = "Eliminated";
                }
                else
                {
                    eq.EstadoEquipo = "Playing";
                }
            } catch { }
        }

        private void ChangeTeamPosition(object sender, EventArgs e, int txtId, string pos)
        {
            try
            {
                int id = Convert.ToInt32(controls[txtId].Text);
                var eq = equiposFases.Find(r => r.IdEquipo == id);
                eq.PosicionEquipo = Convert.ToInt32(pos);
            } catch { }
        }

        void SetIdioma() //Establece el texto segun el idioma seleccionado
        {
            switch (Program.language)
            {
                case "EN": //Ingles
                    lblCantFases.Text = "Amount of phases";
                    lblEstado.Text = "Event state";
                    lblEstado.Location = new Point(69, 290);
                    lblEstadoFase.Text = "Phase state";
                    lblEstadoFase.Location = new Point(489, 77);
                    lblFaseActual.Text = "Phase";
                    lblFaseActual.Location = new Point(175, 13);
                    lblFechaEvento.Text = "Event start date";
                    lblFechaEvento.Location = new Point(56, 178);
                    lblFechaFase.Text = "Phase date";
                    lblFechaFase.Location = new Point(230, 78);
                    lblHoraEvento.Text = "Event start time";
                    lblHoraEvento.Location = new Point(56, 235);
                    lblImageEvent.Text = "Representative image of the event";
                    lblLugarEvento.Text = "Place where the event will take place";
                    lblNombreEvento.Text = "Event name";
                    lblNombreEvento.Location = new Point(128, 53);
                    lblNombreFase.Text = "Phase name";
                    lblNombreFase.Location = new Point(67, 78);
                    lblTipoFase.Text = "Phase type";
                    lblTipoFase.Location = new Point(360, 77);
                    lblTitle.Text = "Event";
                    btnAddEvent.Text = "Add event";
                    btnGoEvent.Text = "Event";
                    btnGoFases.Text = "Phases";
                    btnSelectImage.Text = "Select image";
                    break;
                case "ES": //Español
                    lblCantFases.Text = "Cantidad de fases";
                    lblEstado.Text = "Estado del evento";
                    lblEstado.Location = new Point(54, 290);
                    lblEstadoFase.Text = "Estado de la fase";
                    lblEstadoFase.Location = new Point(474, 77);
                    lblFaseActual.Text = "Fase";
                    lblFaseActual.Location = new Point(178, 13);
                    lblFechaEvento.Text = "Fecha de inicio del evento";
                    lblFechaEvento.Location = new Point(27, 178);
                    lblFechaFase.Text = "Fecha de la fase";
                    lblFechaFase.Location = new Point(217, 78);
                    lblHoraEvento.Text = "Hora de comienzo del evento";
                    lblHoraEvento.Location = new Point(20, 235);
                    lblImageEvent.Text = "Imagen representativa del evento";
                    lblLugarEvento.Text = "Lugar donde se realizara el evento";
                    lblNombreEvento.Text = "Nombre del evento";
                    lblNombreEvento.Location = new Point(100, 53);
                    lblNombreFase.Text = "Nombre de la fase";
                    lblNombreFase.Location = new Point(52, 78);
                    lblTipoFase.Text = "Tipo de fase";
                    lblTipoFase.Location = new Point(355, 77);
                    lblTitle.Text = "Evento";
                    btnAddEvent.Text = "Agregar evento";
                    btnGoEvent.Text = "Evento";
                    btnGoFases.Text = "Fases";
                    btnSelectImage.Text = "Seleccionar imagen";
                    break;
            }
        }

        bool CambiarFormatoFecha(String user, String value = ":")
        {
            return user.Contains(value);
        }

        private void SetControls()
        {
            txtFechaFase.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaFase); };
            txtFechaFase.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaFase); };
            btnGoEvent.Click += (sender, EventArgs) => { btnGoEvent_Click(sender, EventArgs); };
            btnPlusFases.Click += (sender, EventArgs) => { btnPlusFases_Click(sender, EventArgs); };
            btnMinusFases.Click += (sender, EventArgs) => { btnminusFases_Click(sender, EventArgs); };
            cbxFase.SelectedIndexChanged += (sender, EventArgs) => { cbxFase_SelectedIndexChanged(sender, EventArgs); };
            cbxTipoFase.SelectedIndexChanged += (sender, EventArgs) => { cbxTipoFase_SelectedIndexChanged(sender, EventArgs); };
            btnSelectImage.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };
            btnGoFases.Click += (sender, EventArgs) => { btnGoFases_Click(sender, EventArgs); };
            txtHoraEvento.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, txtHoraEvento); };
            txtHoraEvento.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, txtHoraEvento); };
            txtFechaEvento.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, txtFechaEvento); };
            txtFechaEvento.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, txtFechaEvento); };
            btnEventCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };
            picReset.Click += (sender, EventArgs) => { DeleteTeam_Click(sender, EventArgs); };
        }
    }
}