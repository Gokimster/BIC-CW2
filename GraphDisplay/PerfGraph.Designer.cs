﻿namespace GraphDisplay
{
    partial class PerfGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ratesGraph = new ZedGraph.ZedGraphControl();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.meansGraph = new ZedGraph.ZedGraphControl();
            this.paramsInputContainer = new System.Windows.Forms.Panel();
            this.label_use_graphs = new System.Windows.Forms.Label();
            this.checked_useGraphs = new System.Windows.Forms.CheckBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.input_weight_max = new System.Windows.Forms.TextBox();
            this.input_weight_min = new System.Windows.Forms.TextBox();
            this.label_max = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.label_weightInterval = new System.Windows.Forms.Label();
            this.input_crossoverRate = new System.Windows.Forms.TextBox();
            this.label_crossoverrate = new System.Windows.Forms.Label();
            this.input_mutationrate = new System.Windows.Forms.TextBox();
            this.label_mutationrate = new System.Windows.Forms.Label();
            this.input_numofiterations = new System.Windows.Forms.TextBox();
            this.label_numberofinterations = new System.Windows.Forms.Label();
            this.input_popsize = new System.Windows.Forms.TextBox();
            this.label_popsize = new System.Windows.Forms.Label();
            this.checked_activationfn = new System.Windows.Forms.CheckBox();
            this.checked_weights = new System.Windows.Forms.CheckBox();
            this.label_tickboxes = new System.Windows.Forms.Label();
            this.label_selectRadio = new System.Windows.Forms.Label();
            this.fn_complexradio = new System.Windows.Forms.RadioButton();
            this.radfn_xorradio = new System.Windows.Forms.RadioButton();
            this.fn_tanhradio = new System.Windows.Forms.RadioButton();
            this.fn_sineradio = new System.Windows.Forms.RadioButton();
            this.fn_cubicradio = new System.Windows.Forms.RadioButton();
            this.fn_linearradio = new System.Windows.Forms.RadioButton();
            this.individual_MLP_stage = new System.Windows.Forms.Label();
            this.evolution_Stage = new System.Windows.Forms.Label();
            this.paramsInputContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ratesGraph
            // 
            this.ratesGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ratesGraph.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ratesGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ratesGraph.Location = new System.Drawing.Point(3, 2);
            this.ratesGraph.Name = "ratesGraph";
            this.ratesGraph.ScrollGrace = 0D;
            this.ratesGraph.ScrollMaxX = 0D;
            this.ratesGraph.ScrollMaxY = 0D;
            this.ratesGraph.ScrollMaxY2 = 0D;
            this.ratesGraph.ScrollMinX = 0D;
            this.ratesGraph.ScrollMinY = 0D;
            this.ratesGraph.ScrollMinY2 = 0D;
            this.ratesGraph.Size = new System.Drawing.Size(1259, 224);
            this.ratesGraph.TabIndex = 0;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1000;
            // 
            // meansGraph
            // 
            this.meansGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.meansGraph.Location = new System.Drawing.Point(3, 247);
            this.meansGraph.Name = "meansGraph";
            this.meansGraph.ScrollGrace = 0D;
            this.meansGraph.ScrollMaxX = 0D;
            this.meansGraph.ScrollMaxY = 0D;
            this.meansGraph.ScrollMaxY2 = 0D;
            this.meansGraph.ScrollMinX = 0D;
            this.meansGraph.ScrollMinY = 0D;
            this.meansGraph.ScrollMinY2 = 0D;
            this.meansGraph.Size = new System.Drawing.Size(1259, 241);
            this.meansGraph.TabIndex = 1;
            // 
            // paramsInputContainer
            // 
            this.paramsInputContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paramsInputContainer.BackColor = System.Drawing.Color.SeaShell;
            this.paramsInputContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paramsInputContainer.Controls.Add(this.label_use_graphs);
            this.paramsInputContainer.Controls.Add(this.checked_useGraphs);
            this.paramsInputContainer.Controls.Add(this.submit_btn);
            this.paramsInputContainer.Controls.Add(this.input_weight_max);
            this.paramsInputContainer.Controls.Add(this.input_weight_min);
            this.paramsInputContainer.Controls.Add(this.label_max);
            this.paramsInputContainer.Controls.Add(this.label_min);
            this.paramsInputContainer.Controls.Add(this.label_weightInterval);
            this.paramsInputContainer.Controls.Add(this.input_crossoverRate);
            this.paramsInputContainer.Controls.Add(this.label_crossoverrate);
            this.paramsInputContainer.Controls.Add(this.input_mutationrate);
            this.paramsInputContainer.Controls.Add(this.label_mutationrate);
            this.paramsInputContainer.Controls.Add(this.input_numofiterations);
            this.paramsInputContainer.Controls.Add(this.label_numberofinterations);
            this.paramsInputContainer.Controls.Add(this.input_popsize);
            this.paramsInputContainer.Controls.Add(this.label_popsize);
            this.paramsInputContainer.Controls.Add(this.checked_activationfn);
            this.paramsInputContainer.Controls.Add(this.checked_weights);
            this.paramsInputContainer.Controls.Add(this.label_tickboxes);
            this.paramsInputContainer.Controls.Add(this.label_selectRadio);
            this.paramsInputContainer.Controls.Add(this.fn_complexradio);
            this.paramsInputContainer.Controls.Add(this.radfn_xorradio);
            this.paramsInputContainer.Controls.Add(this.fn_tanhradio);
            this.paramsInputContainer.Controls.Add(this.fn_sineradio);
            this.paramsInputContainer.Controls.Add(this.fn_cubicradio);
            this.paramsInputContainer.Controls.Add(this.fn_linearradio);
            this.paramsInputContainer.Location = new System.Drawing.Point(154, 494);
            this.paramsInputContainer.Name = "paramsInputContainer";
            this.paramsInputContainer.Size = new System.Drawing.Size(965, 176);
            this.paramsInputContainer.TabIndex = 2;
            // 
            // label_use_graphs
            // 
            this.label_use_graphs.AutoSize = true;
            this.label_use_graphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_use_graphs.Location = new System.Drawing.Point(814, 45);
            this.label_use_graphs.Name = "label_use_graphs";
            this.label_use_graphs.Size = new System.Drawing.Size(146, 15);
            this.label_use_graphs.TabIndex = 25;
            this.label_use_graphs.Text = "* affects execution speed ";
            // 
            // checked_useGraphs
            // 
            this.checked_useGraphs.AutoSize = true;
            this.checked_useGraphs.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checked_useGraphs.Location = new System.Drawing.Point(818, 12);
            this.checked_useGraphs.Name = "checked_useGraphs";
            this.checked_useGraphs.Size = new System.Drawing.Size(120, 26);
            this.checked_useGraphs.TabIndex = 24;
            this.checked_useGraphs.Text = "use graphs *";
            this.checked_useGraphs.UseVisualStyleBackColor = true;
            this.checked_useGraphs.CheckedChanged += new System.EventHandler(this.checked_useGraphs_CheckedChanged);
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(653, 125);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(140, 27);
            this.submit_btn.TabIndex = 23;
            this.submit_btn.Text = "SUBMIT";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // input_weight_max
            // 
            this.input_weight_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_weight_max.Location = new System.Drawing.Point(694, 67);
            this.input_weight_max.Name = "input_weight_max";
            this.input_weight_max.Size = new System.Drawing.Size(49, 22);
            this.input_weight_max.TabIndex = 22;
            this.input_weight_max.Text = "integer";
            this.input_weight_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // input_weight_min
            // 
            this.input_weight_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_weight_min.Location = new System.Drawing.Point(693, 37);
            this.input_weight_min.Name = "input_weight_min";
            this.input_weight_min.Size = new System.Drawing.Size(49, 22);
            this.input_weight_min.TabIndex = 21;
            this.input_weight_min.Text = "integer";
            this.input_weight_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_max
            // 
            this.label_max.AutoSize = true;
            this.label_max.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_max.Location = new System.Drawing.Point(649, 67);
            this.label_max.Name = "label_max";
            this.label_max.Size = new System.Drawing.Size(39, 21);
            this.label_max.TabIndex = 20;
            this.label_max.Text = "max";
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_min.Location = new System.Drawing.Point(649, 37);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(38, 21);
            this.label_min.TabIndex = 19;
            this.label_min.Text = "min";
            // 
            // label_weightInterval
            // 
            this.label_weightInterval.AutoSize = true;
            this.label_weightInterval.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_weightInterval.Location = new System.Drawing.Point(649, 7);
            this.label_weightInterval.Name = "label_weightInterval";
            this.label_weightInterval.Size = new System.Drawing.Size(125, 22);
            this.label_weightInterval.TabIndex = 18;
            this.label_weightInterval.Text = "Weight interval";
            // 
            // input_crossoverRate
            // 
            this.input_crossoverRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_crossoverRate.Location = new System.Drawing.Point(538, 125);
            this.input_crossoverRate.Name = "input_crossoverRate";
            this.input_crossoverRate.Size = new System.Drawing.Size(71, 22);
            this.input_crossoverRate.TabIndex = 17;
            this.input_crossoverRate.Text = "float.point";
            this.input_crossoverRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_crossoverrate
            // 
            this.label_crossoverrate.AutoSize = true;
            this.label_crossoverrate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_crossoverrate.Location = new System.Drawing.Point(386, 127);
            this.label_crossoverrate.Name = "label_crossoverrate";
            this.label_crossoverrate.Size = new System.Drawing.Size(122, 22);
            this.label_crossoverrate.TabIndex = 16;
            this.label_crossoverrate.Text = "Crossover rate:";
            // 
            // input_mutationrate
            // 
            this.input_mutationrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_mutationrate.Location = new System.Drawing.Point(538, 97);
            this.input_mutationrate.Name = "input_mutationrate";
            this.input_mutationrate.Size = new System.Drawing.Size(71, 22);
            this.input_mutationrate.TabIndex = 15;
            this.input_mutationrate.Text = "float.point";
            this.input_mutationrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_mutationrate
            // 
            this.label_mutationrate.AutoSize = true;
            this.label_mutationrate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mutationrate.Location = new System.Drawing.Point(386, 99);
            this.label_mutationrate.Name = "label_mutationrate";
            this.label_mutationrate.Size = new System.Drawing.Size(117, 22);
            this.label_mutationrate.TabIndex = 14;
            this.label_mutationrate.Text = "Mutation rate:";
            // 
            // input_numofiterations
            // 
            this.input_numofiterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_numofiterations.Location = new System.Drawing.Point(538, 38);
            this.input_numofiterations.Name = "input_numofiterations";
            this.input_numofiterations.Size = new System.Drawing.Size(71, 22);
            this.input_numofiterations.TabIndex = 13;
            this.input_numofiterations.Text = "integer";
            this.input_numofiterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_numberofinterations
            // 
            this.label_numberofinterations.AutoSize = true;
            this.label_numberofinterations.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numberofinterations.Location = new System.Drawing.Point(386, 38);
            this.label_numberofinterations.Name = "label_numberofinterations";
            this.label_numberofinterations.Size = new System.Drawing.Size(150, 22);
            this.label_numberofinterations.TabIndex = 12;
            this.label_numberofinterations.Text = "Num. of iterations:";
            // 
            // input_popsize
            // 
            this.input_popsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_popsize.Location = new System.Drawing.Point(538, 8);
            this.input_popsize.Name = "input_popsize";
            this.input_popsize.Size = new System.Drawing.Size(71, 22);
            this.input_popsize.TabIndex = 11;
            this.input_popsize.Text = "integer";
            this.input_popsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_popsize
            // 
            this.label_popsize.AutoSize = true;
            this.label_popsize.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_popsize.Location = new System.Drawing.Point(386, 8);
            this.label_popsize.Name = "label_popsize";
            this.label_popsize.Size = new System.Drawing.Size(135, 22);
            this.label_popsize.TabIndex = 10;
            this.label_popsize.Text = "Population Size: ";
            // 
            // checked_activationfn
            // 
            this.checked_activationfn.AutoSize = true;
            this.checked_activationfn.Location = new System.Drawing.Point(220, 58);
            this.checked_activationfn.Name = "checked_activationfn";
            this.checked_activationfn.Size = new System.Drawing.Size(117, 17);
            this.checked_activationfn.TabIndex = 9;
            this.checked_activationfn.Text = "Activation Function";
            this.checked_activationfn.UseVisualStyleBackColor = true;
            this.checked_activationfn.CheckedChanged += new System.EventHandler(this.checked_activationfn_CheckedChanged);
            // 
            // checked_weights
            // 
            this.checked_weights.AutoSize = true;
            this.checked_weights.Location = new System.Drawing.Point(220, 34);
            this.checked_weights.Name = "checked_weights";
            this.checked_weights.Size = new System.Drawing.Size(65, 17);
            this.checked_weights.TabIndex = 8;
            this.checked_weights.Text = "Weights";
            this.checked_weights.UseVisualStyleBackColor = true;
            this.checked_weights.CheckedChanged += new System.EventHandler(this.checked_weights_CheckedChanged);
            // 
            // label_tickboxes
            // 
            this.label_tickboxes.AutoSize = true;
            this.label_tickboxes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tickboxes.Location = new System.Drawing.Point(216, 8);
            this.label_tickboxes.Name = "label_tickboxes";
            this.label_tickboxes.Size = new System.Drawing.Size(164, 22);
            this.label_tickboxes.TabIndex = 7;
            this.label_tickboxes.Text = "Parameters to evolve";
            // 
            // label_selectRadio
            // 
            this.label_selectRadio.AutoSize = true;
            this.label_selectRadio.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_selectRadio.Location = new System.Drawing.Point(27, 8);
            this.label_selectRadio.Name = "label_selectRadio";
            this.label_selectRadio.Size = new System.Drawing.Size(183, 22);
            this.label_selectRadio.TabIndex = 6;
            this.label_selectRadio.Text = "Please select a function:";
            // 
            // fn_complexradio
            // 
            this.fn_complexradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fn_complexradio.AutoSize = true;
            this.fn_complexradio.Location = new System.Drawing.Point(75, 152);
            this.fn_complexradio.Name = "fn_complexradio";
            this.fn_complexradio.Size = new System.Drawing.Size(106, 17);
            this.fn_complexradio.TabIndex = 5;
            this.fn_complexradio.TabStop = true;
            this.fn_complexradio.Text = "Complex function";
            this.fn_complexradio.UseVisualStyleBackColor = true;
            this.fn_complexradio.CheckedChanged += new System.EventHandler(this.fn_complexradio_CheckedChanged);
            // 
            // radfn_xorradio
            // 
            this.radfn_xorradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radfn_xorradio.AutoSize = true;
            this.radfn_xorradio.Location = new System.Drawing.Point(75, 128);
            this.radfn_xorradio.Name = "radfn_xorradio";
            this.radfn_xorradio.Size = new System.Drawing.Size(89, 17);
            this.radfn_xorradio.TabIndex = 4;
            this.radfn_xorradio.TabStop = true;
            this.radfn_xorradio.Text = "XOR function";
            this.radfn_xorradio.UseVisualStyleBackColor = true;
            this.radfn_xorradio.CheckedChanged += new System.EventHandler(this.radfn_xorradio_CheckedChanged);
            // 
            // fn_tanhradio
            // 
            this.fn_tanhradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fn_tanhradio.AutoSize = true;
            this.fn_tanhradio.Location = new System.Drawing.Point(75, 104);
            this.fn_tanhradio.Name = "fn_tanhradio";
            this.fn_tanhradio.Size = new System.Drawing.Size(91, 17);
            this.fn_tanhradio.TabIndex = 3;
            this.fn_tanhradio.TabStop = true;
            this.fn_tanhradio.Text = "Tanh function";
            this.fn_tanhradio.UseVisualStyleBackColor = true;
            this.fn_tanhradio.CheckedChanged += new System.EventHandler(this.fn_tanhradio_CheckedChanged);
            // 
            // fn_sineradio
            // 
            this.fn_sineradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fn_sineradio.AutoSize = true;
            this.fn_sineradio.Location = new System.Drawing.Point(75, 81);
            this.fn_sineradio.Name = "fn_sineradio";
            this.fn_sineradio.Size = new System.Drawing.Size(87, 17);
            this.fn_sineradio.TabIndex = 2;
            this.fn_sineradio.TabStop = true;
            this.fn_sineradio.Text = "Sine function";
            this.fn_sineradio.UseVisualStyleBackColor = true;
            this.fn_sineradio.CheckedChanged += new System.EventHandler(this.fn_sineradio_CheckedChanged);
            // 
            // fn_cubicradio
            // 
            this.fn_cubicradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fn_cubicradio.AutoSize = true;
            this.fn_cubicradio.Location = new System.Drawing.Point(75, 57);
            this.fn_cubicradio.Name = "fn_cubicradio";
            this.fn_cubicradio.Size = new System.Drawing.Size(93, 17);
            this.fn_cubicradio.TabIndex = 1;
            this.fn_cubicradio.TabStop = true;
            this.fn_cubicradio.Text = "Cubic function";
            this.fn_cubicradio.UseVisualStyleBackColor = true;
            this.fn_cubicradio.CheckedChanged += new System.EventHandler(this.fn_cubicradio_CheckedChanged);
            // 
            // fn_linearradio
            // 
            this.fn_linearradio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fn_linearradio.AutoSize = true;
            this.fn_linearradio.Location = new System.Drawing.Point(75, 33);
            this.fn_linearradio.Name = "fn_linearradio";
            this.fn_linearradio.Size = new System.Drawing.Size(95, 17);
            this.fn_linearradio.TabIndex = 0;
            this.fn_linearradio.TabStop = true;
            this.fn_linearradio.Text = "Linear function";
            this.fn_linearradio.UseVisualStyleBackColor = true;
            this.fn_linearradio.CheckedChanged += new System.EventHandler(this.fn_linearradio_CheckedChanged);
            // 
            // individual_MLP_stage
            // 
            this.individual_MLP_stage.AutoSize = true;
            this.individual_MLP_stage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.individual_MLP_stage.Location = new System.Drawing.Point(407, 203);
            this.individual_MLP_stage.Name = "individual_MLP_stage";
            this.individual_MLP_stage.Size = new System.Drawing.Size(0, 23);
            this.individual_MLP_stage.TabIndex = 3;
            this.individual_MLP_stage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // evolution_Stage
            // 
            this.evolution_Stage.AutoSize = true;
            this.evolution_Stage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evolution_Stage.Location = new System.Drawing.Point(37, 206);
            this.evolution_Stage.Name = "evolution_Stage";
            this.evolution_Stage.Size = new System.Drawing.Size(0, 23);
            this.evolution_Stage.TabIndex = 4;
            this.evolution_Stage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PerfGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.evolution_Stage);
            this.Controls.Add(this.individual_MLP_stage);
            this.Controls.Add(this.paramsInputContainer);
            this.Controls.Add(this.meansGraph);
            this.Controls.Add(this.ratesGraph);
            this.Name = "PerfGraph";
            this.Text = "PerfGraph";
            this.Load += new System.EventHandler(this.PerfGraph_Load);
            this.paramsInputContainer.ResumeLayout(false);
            this.paramsInputContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl ratesGraph;
        private System.Windows.Forms.Timer UpdateTimer;
        private ZedGraph.ZedGraphControl meansGraph;
        private System.Windows.Forms.Panel paramsInputContainer;
        private System.Windows.Forms.RadioButton radfn_xorradio;
        private System.Windows.Forms.RadioButton fn_tanhradio;
        private System.Windows.Forms.RadioButton fn_sineradio;
        private System.Windows.Forms.RadioButton fn_cubicradio;
        private System.Windows.Forms.RadioButton fn_linearradio;
        private System.Windows.Forms.RadioButton fn_complexradio;
        private System.Windows.Forms.Label label_selectRadio;
        private System.Windows.Forms.Label label_tickboxes;
        private System.Windows.Forms.TextBox input_popsize;
        private System.Windows.Forms.Label label_popsize;
        private System.Windows.Forms.CheckBox checked_activationfn;
        private System.Windows.Forms.CheckBox checked_weights;
        private System.Windows.Forms.TextBox input_numofiterations;
        private System.Windows.Forms.Label label_numberofinterations;
        private System.Windows.Forms.TextBox input_mutationrate;
        private System.Windows.Forms.Label label_mutationrate;
        private System.Windows.Forms.Label label_max;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.Label label_weightInterval;
        private System.Windows.Forms.TextBox input_crossoverRate;
        private System.Windows.Forms.Label label_crossoverrate;
        private System.Windows.Forms.TextBox input_weight_max;
        private System.Windows.Forms.TextBox input_weight_min;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label individual_MLP_stage;
        private System.Windows.Forms.Label evolution_Stage;
        private System.Windows.Forms.Label label_use_graphs;
        private System.Windows.Forms.CheckBox checked_useGraphs;
    }
}