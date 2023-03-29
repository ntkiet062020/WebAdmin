<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucContent_Sample.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.ucContent_Sample" %>
<div class="content">

				        <div class="row">
					        <div class="col-md-12">

						        <div class="col-md-3">
							        <div class="dash-stat light-shadow blue rounded">
								        <span id="stat-1" class="dash-stat-chart">
									        10,8,9,3,5,8,5,10,8,9,3,5,8,5,10,8,9,3,5,8,5,10,8,9,3,5,8,5
								        </span>
								        <div class="dash-stat-cont">
									        <span class="dash-stat-main">1,633</span>
									        <span class="dash-stat-sub">Total Transactions</span>
									        <span class="dash-stat-more">View History <i class="fa fa-arrow-right"></i></span>
								        </div>
							        </div>
						        </div>

						        <div class="col-md-3">
							        <div class="dash-stat light-shadow teal rounded">
								        <span id="stat-2" class="dash-stat-chart">10,8,9,3,5,8,5,7</span>
								        <div class="dash-stat-cont">
									        <span class="dash-stat-main">30%</span>
									        <span class="dash-stat-sub">User Activity Increase</span>
									        <span class="dash-stat-more">View Full Statistic <i class="fa fa-arrow-right"></i></span>
								        </div>
							        </div>
						        </div>

						        <div class="col-md-3">
							        <div class="dash-stat light-shadow red rounded">
								        <span class="dash-stat-icon"><i class="fa fa-users"></i></span>
								        <div class="dash-stat-cont">
									        <span class="dash-stat-main">2,427</span>
									        <span class="dash-stat-sub">Active Users</span>
									        <span class="dash-stat-more">View All Users <i class="fa fa-arrow-right"></i></span>
								        </div>
							        </div>
						        </div>

						        <div class="col-md-3">
							        <div class="dash-stat light-shadow green rounded">
								        <span id="stat-3" class="dash-stat-chart">8,4,0,0,0,0,1,4,4,10,10,10,10,0,0,0,4,6,5,9,10</span>
								        <div class="dash-stat-cont">
									        <span class="dash-stat-main">$10,440</span>
									        <span class="dash-stat-sub">Total Income</span>
									        <span class="dash-stat-more">View History <i class="fa fa-arrow-right"></i></span>
								        </div>
							        </div>
						        </div>

					        </div>

					        <div class="col-md-12 mg-top-20">
						        <div class="col-md-9">
							        <div id="test" class="panel light-shadow white title-transparent rounded" data-toggle="true" data-expand="true">
								        <div class="panel-title">
									        Server Status <span class="label red pull-right">23% Increase</span>
								        </div>
								        <div class="row">
									        <div class="col-md-12">
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">52%</strong><br/>CPU Usage
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">64%</strong><br/>Memory Usage
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">530GB / 2TB</strong><br/>Disk Space
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">200MB / 1GB</strong><br/>Database Space
										        </div>
									        </div>
									        <div class="col-md-12 mg-top-15">
										        <div id="stat-server" class="chart_container" style="width:100%; height:300px"></div>
									        </div>
								        </div>
							        </div>
						        </div>
						        <div class="col-md-3">
							        <div class="panel light-shadow white title-transparent rounded" data-title="Productivity"
							        data-toggle="true" data-expand="true">
								        <div class="row">
									        <div class="col-md-12">
										        <div class="progress-circle blue p80" data-valuenow="80"
										        data-style="m:25px 0 25px calc(50% - 60px)">
											        <span data-style="fs:50"><i class="fa fa-cogs"></i></span>
											        <div class="slice">
												        <div class="bar"></div>
												        <div class="fill"></div>
											        </div>
										        </div>
									        </div>
									        <div class="col-md-12 txt-center mg-bottom-20">
										        <h3><strong>80%</strong></h3>
										        <p data-style="mt:-10">Productivity Increase</p>
									        </div>
									        <div class="col-md-12">
										        <div id="stat-productivity" style="height:107px">
										        1:2,2:4,3:4,2:2,2,5,2:3,3,3:1:4,3,2,3,4,2:2,4:1,1:2,2:4,5,2,3,5:2
										        </div>
									        </div>
								        </div>
							        </div>
						        </div>	
					        </div>

					        <div class="col-md-12 mg-top-20">
						        <div class="col-md-7">
							        <div class="panel light-shadow white title-transparent rounded" data-title="Visitors Statistics" data-toggle="true" data-expand="true">
								        <div class="row">
									        <div class="col-md-12">
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">2,427</strong><br/>Active Users
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">3,536</strong><br/>Sessions
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">10:25</strong><br/>Avg. Session Duration
										        </div>
										        <div class="col-md-3 txt-center">
											        <strong class="txt-md">22,024</strong><br/>Views
										        </div>
									        </div>
									        <div class="col-md-12">
										        <div class="col-md-4">
											        <div class="progress-circle teal" data-valuenow="46"
											        data-style="m:25px 0 25px calc(50% - 60px)">
												        <span>
													        <span>46%<span class="txt-sm block">Bounce Rate</span></span>
												        </span>
												        <div class="slice">
													        <div class="bar"></div>
													        <div class="fill"></div>
												        </div>
											        </div>
										        </div>
										        <div class="col-md-4">
											        <div class="progress-circle magenta" data-valuenow="74"
											        data-style="m:25px 0 25px calc(50% - 60px)">
												        <span>
													        <span>74%<span class="txt-sm block">Engagement</span></span>
												        </span>
												        <div class="slice">
													        <div class="bar"></div>
													        <div class="fill"></div>
												        </div>
											        </div>
										        </div>
										        <div class="col-md-4">
											        <div class="progress-circle green" data-valuenow="62"
											        data-style="m:25px 0 25px calc(50% - 60px)">
												        <span>
													        <span>62%<span class="txt-sm block">Retention</span></span>
												        </span>
												        <div class="slice">
													        <div class="bar"></div>
													        <div class="fill"></div>
												        </div>
											        </div>
										        </div>
									        </div>
								        </div>
							        </div>
						        </div>
						        <div class="col-md-5">
							        <div class="panel light-shadow white title-transparent rounded" data-title="Browsers Statistics <span class='label green pull-right'>Latest Update: <strong>1/2016</strong></span>" data-toggle="true" data-expand="true">
								        <table class="table">
									        <tbody>
										        <tr>
											        <td><strong>Google Chrome</strong></td>
											        <td class="txt-teal">
												        68.0%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar teal" role="progressbar" style="width:68%"></div></div>
											        </td>
										        </tr>
										        <tr>
											        <td><strong>Firefox</strong></td>
											        <td class="txt-blue">
												        19.1%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar blue" role="progressbar" style="width:19.1%"></div></div>
											        </td>
										        </tr>
										        <tr>
											        <td><strong>Internet Explorer</strong></td>
											        <td class="txt-red">
												        6.3%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar red" role="progressbar" style="width:6.3%"></div></div>
											        </td>
										        </tr>
										        <tr>
											        <td><strong>Safari</strong></td>
											        <td class="txt-orange">
												        3.7%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar orange" role="progressbar" style="width:3.7%"></div></div>
											        </td>
										        </tr>
										        <tr>
											        <td><strong>Opera</strong></td>
											        <td class="txt-dark">
												        1.5%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar dark" role="progressbar" style="width:1.5%"></div></div>
											        </td>
										        </tr>
										        <tr>
											        <td><strong>Others</strong></td>
											        <td class="txt-magenta">
												        1.4%
												        <div class="progress progress-sm mg-bottom-0"><div class="progress-bar magenta" role="progressbar" style="width:1.4%"></div></div>
											        </td>
										        </tr>
									        </tbody>
								        </table>
							        </div>
						        </div>
					        </div>
				        </div>

			        </div>