package org.activiti.designer.test;

import static org.junit.Assert.*;

import java.util.HashMap;
import java.util.Map;
import java.io.FileInputStream;

import org.activiti.engine.RepositoryService;
import org.activiti.engine.RuntimeService;
import org.activiti.engine.runtime.ProcessInstance;
import org.activiti.engine.test.ActivitiRule;
import org.junit.Rule;
import org.junit.Test;

public class ProcessTestRpiProcess {

	private String filename = "/home/dani/Development/Repositories/github/ZHAW/SM - Systemarchitektur/code/Aciviti-RPI-Demo/src/main/resources/diagrams/MyRpiProcess.bpmn";

	@Rule
	public ActivitiRule activitiRule = new ActivitiRule();

	@Test
	public void startProcess() throws Exception {
		RepositoryService repositoryService = activitiRule.getRepositoryService();
		repositoryService.createDeployment().addInputStream("rpiProcess.bpmn20.xml",
				new FileInputStream(filename)).deploy();
		RuntimeService runtimeService = activitiRule.getRuntimeService();
		Map<String, Object> variableMap = new HashMap<String, Object>();
		variableMap.put("employee", "kermit");
		variableMap.put("amount", "5");
		ProcessInstance processInstance = runtimeService.startProcessInstanceByKey("rpiProcess", variableMap);
		assertNotNull(processInstance.getId());
		
		org.activiti.engine.task.Task task = activitiRule.getTaskService().createTaskQuery().singleResult();
		assertEquals("Request Review",task.getName());
		
	}
}