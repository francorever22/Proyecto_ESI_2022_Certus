namespace SRD_BackOffice
{
    public partial class MenuCrearEvento : Form
    {
        bool modify, startModify = false;
        String eqName;
        Bitmap imagenCargada = null;
        int index, cantFases = 1, faseSeleccionada = 1, groupAmount = 1, groupSize = 2, eqId, lblId = 0, txtId = 0;
        List<Fase> fases = new List<Fase>();
        List<int> equipos = new List<int>();
        List<Control> controls = new List<Control>();

        public MenuCrearEvento()
        {
            InitializeComponent();
            SetIdioma();

            this.txtFechaFase.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, this.txtFechaFase); };
            this.txtFechaFase.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, this.txtFechaFase); };
            this.btnGoEvent.Click += (sender, EventArgs) => { btnGoEvent_Click(sender, EventArgs); };
            this.btnPlusFases.Click += (sender, EventArgs) => { btnPlusFases_Click(sender, EventArgs); };
            this.btnMinusFases.Click += (sender, EventArgs) => { btnminusFases_Click(sender, EventArgs); };
            this.cbxFase.SelectedIndexChanged += (sender, EventArgs) => { cbxFase_SelectedIndexChanged(sender, EventArgs); };
            this.cbxTipoFase.SelectedIndexChanged += (sender, EventArgs) => { cbxTipoFase_SelectedIndexChanged(sender, EventArgs); };
            this.btnSelectImage.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };
            this.btnGoFases.Click += (sender, EventArgs) => { btnGoFases_Click(sender, EventArgs); };
            this.txtHoraEvento.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, this.txtHoraEvento); };
            this.txtHoraEvento.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, this.txtHoraEvento); };
            this.txtFechaEvento.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, this.txtFechaEvento); };
            this.txtFechaEvento.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, this.txtFechaEvento); };
            this.btnEventCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };

            fases.Add(new Fase());

            cbxTipoFase.SelectedIndex = 0;
            cbxFase.SelectedIndex = 0;
            panelFases.Hide();
            panelBuscadorEquipos.Hide();
        }

        public MenuCrearEvento(int index)
        {
            InitializeComponent();
            SetIdioma();

            this.index = index;
            modify = true;
            startModify = true;
            btnAddEvent.Text = "Modify";
            txtFechaEvento.ForeColor = Color.Black;
            txtFechaFase.ForeColor = Color.Black;
            txtHoraEvento.ForeColor = Color.Black;

            this.txtFechaFase.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, this.txtFechaFase); };
            this.txtFechaFase.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, this.txtFechaFase); };
            this.btnGoEvent.Click += (sender, EventArgs) => { btnGoEvent_Click(sender, EventArgs); };
            this.btnPlusFases.Click += (sender, EventArgs) => { btnPlusFases_Click(sender, EventArgs); };
            this.btnMinusFases.Click += (sender, EventArgs) => { btnminusFases_Click(sender, EventArgs); };
            this.cbxFase.SelectedIndexChanged += (sender, EventArgs) => { cbxFase_SelectedIndexChanged(sender, EventArgs); };
            this.cbxTipoFase.SelectedIndexChanged += (sender, EventArgs) => { cbxTipoFase_SelectedIndexChanged(sender, EventArgs); };
            this.btnSelectImage.Click += (sender, EventArgs) => { btnSelectImage_Click(sender, EventArgs); };
            this.btnGoFases.Click += (sender, EventArgs) => { btnGoFases_Click(sender, EventArgs); };
            this.txtHoraEvento.Enter += (sender, EventArgs) => { txtHora_Enter(sender, EventArgs, this.txtHoraEvento); };
            this.txtHoraEvento.Leave += (sender, EventArgs) => { txtHora_Leave(sender, EventArgs, this.txtHoraEvento); };
            this.txtFechaEvento.Enter += (sender, EventArgs) => { txtFecha_Enter(sender, EventArgs, this.txtFechaEvento); };
            this.txtFechaEvento.Leave += (sender, EventArgs) => { txtFecha_Leave(sender, EventArgs, this.txtFechaEvento); };
            this.btnEventCerrar.Click += (sender, EventArgs) => { btnEventCerrar_Click(sender, EventArgs); };

            var eventos = Logica.DeserializeEventos(Logica.GetJson("DinamicJson\\Eventos.json"));
            Evento evento = eventos[index];

            txtNombreEvento.Text = evento.NombreEvento;
            txtHoraEvento.Text = evento.HoraEvento;
            txtFechaEvento.Text = evento.FechaEvento;
            txtlugarEvento.Text = evento.Lugar;
            cbxEstadoEvento.Text = evento.EstadoEvento;
            cantFases = evento.Fases.Count();
            txtCantFases.Text = "" + cantFases;
            int c = 1;
            foreach (var f in evento.Fases)
            {
                fases.Add(f);
                if (c > 1)
                {
                    cbxFase.Items.Add(c);
                }
                c++;
            }

            Fase fase = fases[0];

            txtFechaFase.Text = fase.FechaFase;
            txtNombreFase.Text = fase.NombreFase;
            cbxEstadoFase.Text = fase.EstadoFase;
            equipos = fase.IdEquiposParticipantes;

            cbxFase.SelectedIndex = 0;
            cbxTipoFase.SelectedIndex = fase.TipoFase - 1;
            panelFases.Hide();
            panelBuscadorEquipos.Hide();
        }

        private void cbxFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (startModify == false)
                {
                    Fase fase = new Fase();
                    fase.NumeroFase = faseSeleccionada;
                    fase.FechaFase = txtFechaFase.Text;
                    fase.NombreFase = txtNombreFase.Text;
                    fase.TipoFase = Convert.ToInt32(cbxTipoFase.Text);
                    fase.IdEquiposParticipantes = equipos;

                    fases.RemoveAt(faseSeleccionada - 1);
                    fases.Insert(faseSeleccionada - 1, fase);
                    faseSeleccionada = Convert.ToInt32(cbxFase.Text);

                    fase = fases[faseSeleccionada - 1];

                    txtNombreFase.Text = Convert.ToString(fase.NombreFase);
                    if (fase.FechaFase == "" || fase.FechaFase == "DD/MM/YYYY")
                    {
                        txtFechaFase.Text = "DD/MM/YYYY";
                        txtFechaFase.ForeColor = Color.DimGray;
                    }
                    else
                    {
                        txtFechaFase.Text = fase.FechaFase;
                        txtFechaFase.ForeColor = Color.Black;
                    }
                    if (fase.IdEquiposParticipantes != null)
                    {
                        equipos = fase.IdEquiposParticipantes;
                    }
                    else { equipos = new List<int>(); }
                    if (fase.TipoFase == 0) { cbxTipoFase.SelectedIndex = 1; cbxTipoFase.SelectedIndex = 0; }
                    else
                    {
                        if (cbxTipoFase.Text == Convert.ToString(fase.TipoFase))
                        {
                            cbxTipoFase.SelectedIndex = 1;
                            cbxTipoFase.SelectedIndex = 0;
                        }
                        cbxTipoFase.SelectedIndex = fase.TipoFase - 1;
                    }
                } else
                {
                    startModify = false;
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cbxTipoFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelEquipos.Controls.Clear();
            switch (cbxTipoFase.Text)
            {
                case "1": //LLaves
                    int p = 8, count = 0;
                    var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
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

                            this.panelEquipos.Controls.Add(p1);

                            for (int j = 0; j < 2; j++)
                            {
                                Panel p2 = new Panel();

                                p2.Size = new Size(225, 25);
                                p2.BorderStyle = BorderStyle.FixedSingle;
                                p2.BackColor = Color.FromArgb(255, 255, 248);
                                p2.TabIndex = 0;
                                p2.Location = new Point(0, 25 * j);

                                Label lbl1 = new Label();

                                lbl1.Size = new Size(190, 15);
                                lbl1.Location = new Point(5, 5);
                                controls.Add(lbl1);

                                TextBox txtID = new TextBox();

                                txtID.Text = "";
                                controls.Add(txtID);

                                if (equipos != null)
                                {
                                    foreach (var eq in equipos)
                                    {
                                        try
                                        {
                                            if (eq.IdEquipo == this.equipos[count])
                                            {
                                                txtID.Text = "" + eq.IdEquipo;
                                                lbl1.Text = eq.NombreEquipo;
                                            }
                                        } catch { }
                                    }
                                }

                                PictureBox pic1 = new PictureBox(); //Boton eliminar

                                pic1.BorderStyle = BorderStyle.FixedSingle;
                                pic1.Size = new Size(12, 12);
                                pic1.Location = new Point(212, 7);
                                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pic1.Image = Properties.Resources.cruz;
                                pic1.Click += (sender, EventArgs) => { DeleteTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID)); };

                                PictureBox pic2 = new PictureBox(); //Boton agregar

                                pic2.BorderStyle = BorderStyle.FixedSingle;
                                pic2.Size = new Size(12, 12);
                                pic2.Location = new Point(200, 7);
                                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                                pic2.Image = Properties.Resources.mas;
                                pic2.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID)); };

                                p1.Controls.Add(p2);
                                p2.Controls.Add(pic2);
                                p2.Controls.Add(pic1);
                                p2.Controls.Add(lbl1);

                                count++;
                            }
                        }
                        p /= 2;
                    }
                    break;
                case "2": //Grupos
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
                    txtGroupSize.Text = "2";
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
                    txtGroupAmount.Text = "1";
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

                    this.panelEquipos.Controls.Add(btnAmountPlus);
                    this.panelEquipos.Controls.Add(btnAmountMinus);
                    this.panelEquipos.Controls.Add(btnSizeMinus);
                    this.panelEquipos.Controls.Add(btnSizePlus);
                    this.panelEquipos.Controls.Add(txtGroupAmount);
                    this.panelEquipos.Controls.Add(txtGroupSize);
                    this.panelEquipos.Controls.Add(lbl2);
                    this.panelEquipos.Controls.Add(lbl3);
                    this.panelEquipos.Controls.Add(p3);

                    groupSize = 2;

                    PhasesGroups(p3);
                    break;
                case "3": //Desparejo
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
                    txtPairsAmount.Text = "1";
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

                    this.panelEquipos.Controls.Add(lbl4);
                    this.panelEquipos.Controls.Add(p4);
                    this.panelEquipos.Controls.Add(txtPairsAmount);
                    this.panelEquipos.Controls.Add(btnAmountPPlus);
                    this.panelEquipos.Controls.Add(btnAmountPMinus);

                    PhasesGroups(p4);
                    break;
                case "4": //Posición
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

                    this.panelEquipos.Controls.Add(lbl5);
                    this.panelEquipos.Controls.Add(p5);
                    this.panelEquipos.Controls.Add(txtTableSize);
                    this.panelEquipos.Controls.Add(btnSizeTPlus);
                    this.panelEquipos.Controls.Add(btnSizeTMinus);

                    groupAmount = 1;

                    PhasesGroups(p5);
                    break;
                case "5": //Eliminatorias
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

                    this.panelEquipos.Controls.Add(lbl6);
                    this.panelEquipos.Controls.Add(p6);
                    this.panelEquipos.Controls.Add(txtTableESize);
                    this.panelEquipos.Controls.Add(btnSizeEPlus);
                    this.panelEquipos.Controls.Add(btnSizeEMinus);

                    groupAmount = 1;

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
                this.Hide();
                MainMenu main = new MainMenu();
                main.StartPosition = FormStartPosition.CenterParent;
                main.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                MenuManageEvents manageEvents = new MenuManageEvents();
                manageEvents.StartPosition = FormStartPosition.CenterParent;
                manageEvents.ShowDialog();
                this.Close();
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

        private void LookTeam_Click(object sender, EventArgs e, int lblI, int txtId)
        {
            panelBuscadorEquipos.Show();
            this.lblId = lblI;
            this.txtId = txtId;

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

            Button btn1 = new Button();

            btn1.Size = new Size(80, 20);
            btn1.Location = new Point(136, 50);
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btn1.Text = "Add";
            btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, eqName, eqId); };

            btnBuscar.Click += (sender, EventArgs) => { BuscarEquipo(sender, EventArgs, buscador.Text, panelContenedor); };

            this.panelBuscadorEquipos.Controls.Add(panelPrincipal);
            this.panelBuscadorEquipos.Controls.Add(buscador);
            this.panelBuscadorEquipos.Controls.Add(btnBuscar);
            this.panelBuscadorEquipos.Controls.Add(btn1);
            panelPrincipal.Controls.Add(panelLabels);
            panelPrincipal.Controls.Add(panelContenedor);
            panelLabels.Controls.Add(lblEquipo);
            panelLabels.Controls.Add(lblOrigen);
            panelLabels.Controls.Add(lblId);

            var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
            int count = 0;

            foreach (var eq in equipos)
            {
                Panel p1 = new Panel();

                p1.Location = new Point(0, 25 * count);
                p1.Size = new Size(334, 25);

                Label lbl1 = new Label();

                lbl1.Text = ""+eq.IdEquipo;
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
                btn2.Click += (sender, EventArgs) => { BtnChange(sender, EventArgs, btn2, panelContenedor, eq.NombreEquipo, eq.IdEquipo); };

                panelContenedor.Controls.Add(p1);
                p1.Controls.Add(btn2);
                p1.Controls.Add(lbl3);
                p1.Controls.Add(lbl2);
                p1.Controls.Add(lbl1);

                count++;
            }
        }

        private void BtnChange(object sender, EventArgs e, Button b, Panel p, string name, int id)
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
            eqName = name;
            eqId = id;
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                Fase fase = new Fase();
                fase.NumeroFase = faseSeleccionada;
                fase.FechaFase = txtFechaFase.Text;
                fase.NombreFase = txtNombreFase.Text;
                fase.TipoFase = Convert.ToInt32(cbxTipoFase.Text);
                fase.IdEquiposParticipantes = equipos;
                fase.EstadoFase = cbxEstadoFase.Text;

                fases.RemoveAt(faseSeleccionada - 1);
                fases.Insert(faseSeleccionada - 1, fase);

                var eventos = Logica.DeserializeEventos(Logica.GetJson("DinamicJson\\Eventos.json"));
                Evento evento = new Evento();

                Random r = new Random();

                evento.IdEvento = r.Next(1, 10000);
                evento.FechaEvento = txtFechaEvento.Text;
                evento.NombreEvento = txtNombreEvento.Text;
                evento.HoraEvento = txtHoraEvento.Text;
                evento.EstadoEvento = cbxEstadoEvento.Text;
                evento.Lugar = txtlugarEvento.Text;
                //evento.LogoEvento = imgEventSelected.Image;
                evento.Fases = fases;

                if (eventos != null)
                {
                    eventos.Add(evento);
                    Logica.SerializeEventos(eventos);
                }
                else
                {
                    eventos = new List<Evento>();
                    eventos.Add(evento);
                    Logica.SerializeEventos(eventos);
                }
                MessageBox.Show("Event added correctly");
            } else
            {
                if (txtFechaEvento.Text != "" && txtFechaFase.Text != "" && txtHoraEvento.Text != "" && txtlugarEvento.Text != "" && txtNombreEvento.Text != "" && txtNombreFase.Text != "")
                {
                    var eventos = Logica.DeserializeEventos(Logica.GetJson("DinamicJson\\Eventos.json"));
                    Evento evento = eventos[index];
                    if (!(txtNombreEvento.Text == evento.NombreEvento &&
                        txtHoraEvento.Text == evento.HoraEvento &&
                        txtlugarEvento.Text == evento.Lugar &&
                        cbxEstadoEvento.Text == evento.EstadoEvento &&
                        fases == evento.Fases))
                    {
                        DialogResult dialogResult1 = MessageBox.Show("Are you sure of this?", "Modify event", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            evento.FechaEvento = txtFechaEvento.Text;
                            evento.NombreEvento = txtNombreEvento.Text;
                            evento.HoraEvento = txtHoraEvento.Text;
                            evento.EstadoEvento = cbxEstadoEvento.Text;
                            evento.Lugar = txtlugarEvento.Text;
                            //evento.LogoEvento = imgEventSelected.Image;
                            evento.Fases = fases;

                            Logica.SerializeEventos(eventos);

                            this.Hide();
                            MenuManageEvents manageEvents = new MenuManageEvents();
                            manageEvents.StartPosition = FormStartPosition.CenterParent;
                            manageEvents.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (Program.language == "EN")
                        {
                            MessageBox.Show("The entered data equals the previous one");
                        }
                        else if (Program.language == "ES")
                        {
                            MessageBox.Show("La información ingresada es la misma que la anterior");
                        }
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

        private void BuscarEquipo(object sender, EventArgs e, string busqueda, Panel p)
        {
            p.Controls.Clear();

            var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
            int count = 0;

            foreach (var eq in equipos)
            {
                if (busqueda == Convert.ToString(eq.IdEquipo) || eq.NombreEquipo.Contains(busqueda) || eq.PaisOrigen.Contains(busqueda))
                {
                    Panel p1 = new Panel();

                    p1.Location = new Point(0, 25 * count);
                    p1.Size = new Size(334, 25);

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
                    btn1.Click += (sender, EventArgs) => { AddTeam(sender, EventArgs, eq.NombreEquipo, eq.IdEquipo); };

                    p.Controls.Add(p1);
                    p1.Controls.Add(btn1);
                    p1.Controls.Add(lbl3);
                    p1.Controls.Add(lbl2);
                    p1.Controls.Add(lbl1);

                    count++;
                }
            }
        }

        private void DeleteTeam_Click(object sender, EventArgs e, int lbl, int idT)
        {
            var lbl1 = controls[lbl];
            var id = controls[idT];
            lbl1.Text = "";
            foreach(var eq in equipos)
            {
                if (eq == Convert.ToInt32(id.Text))
                {
                    equipos.Remove(eq);
                    return;
                }
            }
            id.Text = "";
        }

        private void AddTeam(object sender, EventArgs e, string name, int id)
        {
            var lbl1 = controls[lblId];
            var txt = controls[txtId];
            lbl1.Text = name;
            txt.Text = ""+id;
            equipos.Add(id);

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

        private void PhasesGroups(Panel p)
        {
            p.Controls.Clear();
            int x = 0, y = 0, count = 0;
            var equipos = Logica.DeserializeEquipos(Logica.GetJson("DinamicJson\\Equipos.json"));
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
                    controls.Add(lbl1);

                    TextBox txtID = new TextBox();

                    txtID.Text = "";
                    controls.Add(txtID);

                    if (modify == true)
                    {
                        foreach (var eq in equipos)
                        {
                            try
                            {
                                if (eq.IdEquipo == this.equipos[count])
                                {
                                    txtID.Text = "" + eq.IdEquipo;
                                    lbl1.Text = eq.NombreEquipo;
                                }
                            }
                            catch { }
                        }
                    }

                    PictureBox pic1 = new PictureBox(); //Boton eliminar

                    pic1.BorderStyle = BorderStyle.FixedSingle;
                    pic1.Size = new Size(12, 12);
                    pic1.Location = new Point(212, 7);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.Image = Properties.Resources.cruz;
                    pic1.Click += (sender, EventArgs) => { DeleteTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID)); };

                    PictureBox pic2 = new PictureBox(); //Boton agregar

                    pic2.BorderStyle = BorderStyle.FixedSingle;
                    pic2.Size = new Size(12, 12);
                    pic2.Location = new Point(200, 7);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Image = Properties.Resources.mas;
                    pic2.Click += (sender, EventArgs) => { LookTeam_Click(sender, EventArgs, controls.IndexOf(lbl1), controls.IndexOf(txtID)); };

                    p.Controls.Add(p2);
                    p2.Controls.Add(lbl1);
                    p2.Controls.Add(pic1);
                    p2.Controls.Add(pic2);
                }
                if (i % 2 != 0 || i == 1)
                {
                    y = (groupSize + 1) * 25 + 50 ;
                }
                else
                {
                    y = 0; x += 250;
                }
            }
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
    }
}
